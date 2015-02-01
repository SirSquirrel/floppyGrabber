using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * A script that manages the ui elements of the Character Select screen,
 * so the player can iterate over the possible characters and those characters
 * will be displayed on the screen.
 */

public class CharSelect : MonoBehaviour {

	GameObject UIElements_root;

	Dictionary<string, Transform> uiElements = new Dictionary<string, Transform> ();

	Character[] selectBox_p1;
	Character[] selectBox_p2;
	int currentBox_p1;
	int currentBox_p2;

	int cha_num = 2;

	bool p1selected = false;
	bool p2selected = false;

	bool p1moving = false;
	bool p2moving = false;

	public class Character {
		
		public SpriteRenderer selector;
		public SpriteRenderer character;

		public Character(SpriteRenderer sel, SpriteRenderer cha) {
			this.selector = sel;
			this.character = cha;
		}
	}

	// Use this for initialization
	void Start () {

		UIElements_root = GameObject.Find ("UIElements");
		Transform temp_sel;
		Transform temp_cha;

		//Grabs all the possible selector related gameobjects.
		foreach (Transform t in UIElements_root.transform) {
			uiElements.Add(t.name, t);
			Debug.Log(t.name + " found.");
		}

		selectBox_p1 = new Character[cha_num];
		selectBox_p2 = new Character[cha_num];
		currentBox_p1 = 0;
		currentBox_p2 = 0;

		/*
		 * Specific character implementation of selector.
		 * Player one.
		 */

		uiElements.TryGetValue ("p1_selector_1", out temp_sel);
		uiElements.TryGetValue ("whiteT_P1", out temp_cha);

		selectBox_p1 [0] = new Character (
			temp_sel.GetComponent<SpriteRenderer>(), temp_cha.GetComponent<SpriteRenderer>());

		uiElements.TryGetValue ("p1_selector_2", out temp_sel);
		uiElements.TryGetValue ("pirate_P1", out temp_cha);
		
		selectBox_p1 [1] = new Character (
			temp_sel.GetComponent<SpriteRenderer>(), temp_cha.GetComponent<SpriteRenderer>());

		//Player two.

		uiElements.TryGetValue ("p2_selector_1", out temp_sel);
		uiElements.TryGetValue ("whiteT_P2", out temp_cha);
		
		selectBox_p2 [0] = new Character (
			temp_sel.GetComponent<SpriteRenderer>(), temp_cha.GetComponent<SpriteRenderer>());

		uiElements.TryGetValue ("p2_selector_2", out temp_sel);
		uiElements.TryGetValue ("pirate_P2", out temp_cha);
		
		selectBox_p2 [1] = new Character (
			temp_sel.GetComponent<SpriteRenderer>(), temp_cha.GetComponent<SpriteRenderer>());
	
		//Sets initial off state for all other selectors.  Should work in general case.
		for (int i = 1; i < cha_num; i++) {

			selectBox_p1[i].character.enabled = false;
			selectBox_p1[i].selector.enabled = false;

			selectBox_p2[i].character.enabled = false;
			selectBox_p2[i].selector.enabled = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!p1selected) {
			this.KeyboardBehaviour ();
			this.P2GamepadBehaviour ();
		} else {
			if (Input.GetKeyDown(KeyCode.Escape) 
			    || Input.GetKeyDown(KeyCode.Backspace) 
			    || Input.GetButtonDown("P1Cancel") )
				p1selected = false;
		}
		if (!p2selected) {
			this.P1GamepadBehaviour ();
		} else {
			if (Input.GetButtonDown("P2Cancel"))
			    p2selected = false;
		}

		/*
		 * If we're here then we're ready to proceed.
		 */
		if (p1selected && p2selected) {
			AutoFade.LoadLevel ("LevelSelect", 3, 1, Color.black);
		}
	}

	void KeyboardBehaviour() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			p1selected = true;
			this.announce(currentBox_p1);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			this.p1Disable(currentBox_p1);
			if (currentBox_p1 == 0) {
				currentBox_p1 = selectBox_p1.Length - 1;
			}
			else
			{
				currentBox_p1--;
			}
			this.p1Enable (currentBox_p1);
			this.p1Sound();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.p1Disable(currentBox_p1);
			if (currentBox_p1 == cha_num - 1) {
				currentBox_p1 = 0;
			}
			else
			{
				currentBox_p1++;
			}
			this.p1Enable (currentBox_p1);
			this.p1Sound();
		}
	}

	void P1GamepadBehaviour() {
		if (Input.GetButtonDown ("P2Submit")) {
			p1selected = true;
			this.announce(currentBox_p1);
		}
		if (Input.GetAxis("P2XBox360LeftStickHorizontal") > 0.9) {
			this.p1Disable(currentBox_p1);
			if (currentBox_p1 == 0) {
				currentBox_p1 = selectBox_p1.Length - 1;
			}
			else
			{
				currentBox_p1--;
			}
			this.p1Enable (currentBox_p1);
			this.p1Sound();
		}
		if (Input.GetAxis("P2XBox360LeftStickHorizontal") < -0.9) {
			this.p1Disable(currentBox_p1);
			if (currentBox_p1 == cha_num - 1) {
				currentBox_p1 = 0;
			}
			else
			{
				currentBox_p1++;
			}
			this.p1Enable (currentBox_p1);
			this.p1Sound();
		}
	}

	void P2GamepadBehaviour() {
		if (Input.GetButtonDown ("P1Submit")) {
			p2selected = true;
			this.announce(currentBox_p2);
		}
		if (Input.GetAxis("XBox360LeftStickHorizontal") > 0.9) {
			this.p2Disable(currentBox_p2);
			if (currentBox_p2 == 0) {
				currentBox_p2 = selectBox_p2.Length - 1;
			}
			else
			{
				currentBox_p2--;
			}
			this.p2Enable (currentBox_p2);
			this.p2Sound();
		}
		if (Input.GetAxis("XBox360LeftStickHorizontal") < -0.9) {
			this.p2Disable(currentBox_p1);
			if (currentBox_p2 == cha_num - 1) {
				currentBox_p2 = 0;
			}
			else
			{
				currentBox_p2++;
			}
			this.p2Enable (currentBox_p1);
			this.p2Sound();
		}
	}

	/*
	 * Turns off selector for P1
	 */
	void p1Disable(int cur) {
		selectBox_p1 [cur].selector.renderer.enabled = false;
		selectBox_p1 [cur].character.renderer.enabled = false;
	}

	void p1Enable(int cur) {
		selectBox_p1 [cur].selector.renderer.enabled = true;
		selectBox_p1 [cur].character.renderer.enabled = true;
	}

	void p2Disable(int cur) {
		selectBox_p2 [cur].selector.renderer.enabled = false;
		selectBox_p2 [cur].character.renderer.enabled = false;
	}
	
	void p2Enable(int cur) {
		selectBox_p2 [cur].selector.renderer.enabled = true;
		selectBox_p2 [cur].character.renderer.enabled = true;
	}

	void p1Sound() {
		AudioSource beep = GameObject.Find ("p1Audio").audio;
		beep.Play();
	}

	void p2Sound() {
		AudioSource beep = GameObject.Find ("p2Audio").audio;
		beep.Play();
	}

	void announce(int cha_num) {

	}
}