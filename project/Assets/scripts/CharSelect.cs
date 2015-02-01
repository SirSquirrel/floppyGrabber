using UnityEngine;
using System.Collections;

/*
 * 
 * 
 */

public class CharSelect : MonoBehaviour {

	GameObject p1_selector_1;
	GameObject p2_selector_1;
	GameObject p1_selector_2;
	GameObject p2_selector_2;

	GameObject whiteT_P1;
	GameObject whiteT_P2;

	Character[] selectBox_p1;
	Character[] selectBox_p2;
	int currentBox_p1;
	int currentBox_p2;

	public class Character {
		
		public GameObject selector;
		public GameObject character;

		public Character(GameObject sel, GameObject cha) {
			this.selector = sel;
			this.character = cha;
		}
	}

	// Use this for initialization
	void Start () {
		selectBox_p1 = new Character[2];
		selectBox_p2 = new Character[2];
		currentBox_p1 = 0;
		currentBox_p2 = 0;

		//selectBox_p1[0] = new Character(
			//p1_selector_1.GetComponent<Sprite>(), whiteT_P1.GetComponent<Sprite>());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (currentBox_p1 == 0) {
				currentBox_p1 = selectBox_p1.Length - 1;
			}
			else
			{
				currentBox_p1--;
			}
			this.ScreenRefresh1();
		}


	}

	/*
	 * A method to update the screen after a player has changed 
	 * their character selection.
	 */
	void ScreenRefresh1() {
		foreach (Character c in selectBox_p1) {
			c.character.renderer.enabled = false;
			c.selector.renderer.enabled = false;
		}
		selectBox_p1 [currentBox_p1].selector.renderer.enabled = true;
		selectBox_p1 [currentBox_p1].character.renderer.enabled = true;
	}
}