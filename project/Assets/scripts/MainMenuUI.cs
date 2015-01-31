using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			AutoFade.LoadLevel ("CharSelect", 3, 1, Color.black);
		}
	}


}
