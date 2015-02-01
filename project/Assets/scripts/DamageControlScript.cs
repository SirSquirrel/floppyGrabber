using UnityEngine;
using System.Collections;

public class DamageControlScript : gettinHit {

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
	if(health<=0)
	{
	lose ();
	}
	}
	void lose()
	{
	Application.LoadLevel(0);
	}
}
