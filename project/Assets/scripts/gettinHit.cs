using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gettinHit : MonoBehaviour {

	public float health = 100;
	public List<int> ignoredLayers;
	public Transform bloodPrefab;
	public int maxAmountBloodPrefabs = 20;
	private GameObject[] bloodInstances;
	public Transform bloodPosition;
	public Transform bloodRotation;
	public int bloodLocalRotationYOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(health<=0)
	{
	transform.parent = null;
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
		
				for(float i = 0; i < collision.relativeVelocity.magnitude*collision.gameObject.rigidbody2D.mass*AStats.multiplier;i = i + 5f)
			{
				bloodRotation.Rotate((float) 0, (float) bloodLocalRotationYOffset, (float) 0);
				Transform transform = Object.Instantiate(bloodPrefab, bloodPosition.position, bloodRotation.rotation) as Transform;
				bloodInstances = GameObject.FindGameObjectsWithTag("blood");
				if ((bloodInstances).Length >= maxAmountBloodPrefabs)
				{
					Destroy(bloodInstances[0]);
				}
			}
		}
	}
	}
}
