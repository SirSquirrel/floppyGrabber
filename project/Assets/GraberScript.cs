using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraberScript : MonoBehaviour {

	public bool grabbing;
	public float speed = 10;
	public Queue<int> layerList = new Queue<int>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rigidbody2D.AddForce(new Vector2(Input.GetAxis("Horizontal2")*speed,Input.GetAxis("Vertical2")*speed));
		if(Input.GetKey(KeyCode.Space))
		{
		grabbing = true;
		}
		else
		{
		grabbing = false;
		}
		//transform.parent.rigidbody2D.AddForce(new Vector2(-Input.GetAxis("Horizontal2")*speed,-Input.GetAxis("Vertical2")*speed));
		if(!grabbing&&transform.parent.childCount>1)
		{
			for(int i = 1; i<=transform.parent.childCount;i++)
			{
				Transform grabbed = transform.parent.GetChild(i);
				//grabbed.gameObject.rigidbody2D.isKinematic = false;
				grabbed.gameObject.layer = layerList.Dequeue();
				DistanceJoint2D newJoint = grabbed.gameObject.GetComponent<DistanceJoint2D>();
				Component.Destroy(newJoint);
				//grabbed.gameObject.rigidbody2D.velocity = rigidbody2D.velocity;
				grabbed.parent = null;
				//rigidbody2D.mass -= grabbed.gameObject.rigidbody2D.mass;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(grabbing)
		{
		if(collision.gameObject.layer != 10)
		{
		layerList.Enqueue(collision.gameObject.layer);
		collision.gameObject.transform.parent = transform.parent;
		collision.gameObject.layer = gameObject.layer;
		collision.gameObject.AddComponent("DistanceJoint2D");
		DistanceJoint2D newJoint = collision.gameObject.GetComponent<DistanceJoint2D>();
		newJoint.connectedBody = rigidbody2D;
		//collision.gameObject.rigidbody2D.isKinematic = true;
		//rigidbody2D.mass += collision.gameObject.rigidbody2D.mass;
		}
		}
	}
}
