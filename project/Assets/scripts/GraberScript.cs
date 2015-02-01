using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraberScript : MonoBehaviour {

	public bool player1;
	public bool grabbing;
	public bool wasGrabbing;
	public float grabRadius = 1;
	public float speed = 50;
	public Queue<int> layerList = new Queue<int>();
	public Queue<GameObject> grabbedList = new Queue<GameObject>();
	public GameObject hand1;
	public GameObject hand2;
	public GameObject torso;
	// Use this for initialization
	void Start () {
		hand1.collider2D.enabled = false;
		hand2.collider2D.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(player1)
	{
		transform.rigidbody2D.AddForce(new Vector2(Input.GetAxis("Horizontal2")*speed,Input.GetAxis("Vertical2")*speed));
		torso.rigidbody2D.AddForce(new Vector2(-Input.GetAxis("Horizontal2")*speed,-Input.GetAxis("Vertical2")*speed));
	}
	
	if(!player1)
	{
			transform.rigidbody2D.AddForce(new Vector2(Input.GetAxis("XBox360RightStickHorizontal")*speed,Input.GetAxis("XBox360RightStickVertical")*speed));
			torso.rigidbody2D.AddForce(new Vector2(-Input.GetAxis("XBox360RightStickHorizontal")*speed,-Input.GetAxis("XBox360RightStickVertical")*speed));
	}
		if(!grabbing&&grabbedList.Count>0)
		{
			for(int i = 0; i<=grabbedList.Count;i++)
			{
				Transform grabbed = grabbedList.Dequeue().transform;
				//grabbed.gameObject.rigidbody2D.isKinematic = false;
				grabbed.gameObject.layer = layerList.Dequeue();
				DistanceJoint2D newJoint = grabbed.gameObject.GetComponent<DistanceJoint2D>();
				Component.Destroy(newJoint);
				//grabbed.gameObject.rigidbody2D.velocity = rigidbody2D.velocity;
				//grabbed.parent = null;
				//rigidbody2D.mass -= grabbed.gameObject.rigidbody2D.mass;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{

	}

	void Update()
	{
		
		if((player1&&Input.GetKey(KeyCode.Space)) || (!player1 && Input.GetButton("XBox360A")))
		{
			grabbing = true;
			hand1.collider2D.enabled = true;
			hand2.collider2D.enabled = true;
		}
		else
		{
			grabbing = false;
			hand1.collider2D.enabled = false;
			hand2.collider2D.enabled = false;
			wasGrabbing = false;
		}

		if(grabbing&&!wasGrabbing)
		{
			Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position,grabRadius);
			foreach (Collider2D collision in collisions)
			{
			if(player1)
			{
					if(collision.gameObject.layer != LayerMask.NameToLayer("Background")&& collision.gameObject.layer != LayerMask.NameToLayer("Player1") && collision.gameObject.layer != LayerMask.NameToLayer("ground")&&collision.gameObject.layer != LayerMask.NameToLayer("groundCollide"))
					{
						layerList.Enqueue(collision.gameObject.layer);
						//collision.gameObject.transform.parent = transform.parent;
						grabbedList.Enqueue(collision.gameObject);
						if(collision.gameObject.layer != 12 && collision.gameObject.layer != 13)
						{
							collision.gameObject.layer = gameObject.layer;
						}
						collision.gameObject.AddComponent("DistanceJoint2D");
						DistanceJoint2D newJoint = collision.gameObject.GetComponent<DistanceJoint2D>();
						newJoint.connectedBody = rigidbody2D;
						//collision.gameObject.rigidbody2D.isKinematic = true;
						//rigidbody2D.mass += collision.gameObject.rigidbody2D.mass;
						wasGrabbing = true;
					}
			}
				
			if(!player1)
			{
				if(collision.gameObject.layer != LayerMask.NameToLayer("Background")&& collision.gameObject.layer != LayerMask.NameToLayer("Player2") && collision.gameObject.layer != LayerMask.NameToLayer("ground")&&collision.gameObject.layer != LayerMask.NameToLayer("groundCollide"))
				{
					layerList.Enqueue(collision.gameObject.layer);
					//collision.gameObject.transform.parent = transform.parent;
					grabbedList.Enqueue(collision.gameObject);
						if(collision.gameObject.layer != 12 || collision.gameObject.layer != 15 )
					{
						collision.gameObject.layer = gameObject.layer;
					}
					collision.gameObject.AddComponent("DistanceJoint2D");
					DistanceJoint2D newJoint = collision.gameObject.GetComponent<DistanceJoint2D>();
					newJoint.connectedBody = rigidbody2D;
					//collision.gameObject.rigidbody2D.isKinematic = true;
					//rigidbody2D.mass += collision.gameObject.rigidbody2D.mass;
					wasGrabbing = true;
					}
				}
			}
		}
	}

}
