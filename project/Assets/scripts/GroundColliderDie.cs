using UnityEngine;
using System.Collections;

public class GroundColliderDie : MonoBehaviour {

	public GameObject leg1;
	public GameObject leg2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(leg1.transform.parent == null && leg2.transform.parent == null)
	{
	GameObject.Destroy(gameObject);
	}
	}
}
