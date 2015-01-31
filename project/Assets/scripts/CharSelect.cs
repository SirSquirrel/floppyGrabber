using UnityEngine;
using System.Collections;

public class CharSelect : MonoBehaviour {

	ArrayList<int> selectBox;
	int currentBox;

	// Use this for initialization
	void Start () {
		selectBox = new ArrayList (2);
		currentBox = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {

		}
	}
}
