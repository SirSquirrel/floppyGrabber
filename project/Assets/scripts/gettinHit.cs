using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gettinHit : MonoBehaviour {

	public float health = 100;
	public List<int> ignoredLayers;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(health<=0)
	{
	transform.parent = null;
	if(transform.childCount>0)
	{
		Transform chil = transform.GetChild(0);
		HingeJoint2D childJoint = chil.GetComponent<HingeJoint2D>();
		Component.Destroy(childJoint);
	}
	HingeJoint2D newJoint = gameObject.GetComponent<HingeJoint2D>();
	Component.Destroy(newJoint);
	}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
	if(!ignoredLayers.Contains(collision.gameObject.layer))
	{
		hittinStuff AStats = collision.gameObject.GetComponent<hittinStuff>();
		if(collision.relativeVelocity.magnitude>1)
		{
		health = health - (collision.relativeVelocity.magnitude*collision.gameObject.rigidbody2D.mass*AStats.multiplier);
		}
	}
	}
}
