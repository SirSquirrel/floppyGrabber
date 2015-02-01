using UnityEngine;
using System.Collections;

public class ropeBehavior : MonoBehaviour {
	HingeJoint2D[] hinge;
	// Use this for initialization
	void Start () {
		hinge = GetComponents<HingeJoint2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag== "Sharp")
			cutTheRope ();
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag=="Sharp")
			cutTheRope ();
	}
	void cutTheRope()
	{
		if(hinge!=null)
		{
			bool found = false;
			foreach(HingeJoint2D h in hinge)
			if (h != null) 
			{
				Destroy(h);
				found = true;
			}
			if(found)
				transform.parent = null;
		}
	}
}
