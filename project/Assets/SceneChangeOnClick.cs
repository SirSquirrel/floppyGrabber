using UnityEngine;
using System.Collections;

public class SceneChangeOnClick : MonoBehaviour {

	public int sceneNumber = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
	Application.LoadLevel(sceneNumber);
	}
}
