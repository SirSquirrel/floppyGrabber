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
	public int hitFeedback = 21;
	float minHitMagnitude=15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		renderer.material.color = Color.white;
	if(health<=0)
	{
	transform.parent = null;
	HingeJoint2D newJoint = gameObject.GetComponent<HingeJoint2D>();
	Component.Destroy(newJoint);
	}
		else if(hitFeedback <= 20)
		{
			if(hitFeedback < 5 || hitFeedback < 15 && hitFeedback > 10)
			{
				renderer.material.color = Color.white;
			}
			else if((hitFeedback < 10 || hitFeedback >= 15))
			{
				renderer.material.color = Color.red;
			}
			hitFeedback ++;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{

		if(!ignoredLayers.Contains(collision.gameObject.layer))
		{
			hittinStuff AStats = collision.gameObject.GetComponent<hittinStuff>();
			Debug.Log (collision.relativeVelocity.magnitude);
			if(collision.relativeVelocity.magnitude>minHitMagnitude)
			{
				health = health - (collision.relativeVelocity.magnitude*collision.gameObject.rigidbody2D.mass*AStats.multiplier);
				hitFeedback = 0;
				for(float i = 0; i < collision.relativeVelocity.magnitude*collision.gameObject.rigidbody2D.mass*AStats.multiplier;i = i + 5f)
				{
					Transform bTransform = Object.Instantiate(bloodPrefab, bloodPosition.position, transform.rotation) as Transform;
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
