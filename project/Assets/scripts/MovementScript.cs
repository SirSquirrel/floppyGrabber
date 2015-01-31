using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public bool player1;
	public float accel_Force;
	public float max_speed;
	public float torque;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float speed = Input.GetAxis ("Horizontal") * accel_Force;
		Vector2 temp = new Vector2 ((float)speed, (float)0);
		if(!((speed>0&&rigidbody2D.velocity.x>max_speed)||(speed<0&&rigidbody2D.velocity.x<-max_speed)))
			rigidbody2D.AddForce (temp);

		if (rigidbody2D.rotation > 0 && rigidbody2D.rotation < 180)
			rigidbody2D.AddTorque (-torque);
		else
			rigidbody2D.AddTorque (torque);
	
	}
}