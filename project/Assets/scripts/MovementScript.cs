using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public bool player1;

	public float accel_Force;
	public float max_speed;
	public float torque;
	public int footSpeed;

	public GameObject foot1;
	public GameObject foot2;

	HingeJoint2D hinge1;
	HingeJoint2D hinge2;

	int runCount = 0;

	// Use this for initialization
	void Start () {
		hinge1 = (HingeJoint2D)foot1.GetComponent<HingeJoint2D> ();
		hinge1.useMotor = true;

		hinge2 = (HingeJoint2D)foot2.GetComponent<HingeJoint2D> ();
		hinge2.useMotor = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float speed;
		if(player1)
		{
			speed = Input.GetAxis ("Horizontal") * accel_Force;
		}
		else
		{
			speed = Input.GetAxis ("XBox360LeftStickHorizontal") * accel_Force;
		}
		Vector2 temp = new Vector2 ((float)speed, (float)0);
		if(!((speed>0&&rigidbody2D.velocity.x>max_speed)||(speed<0&&rigidbody2D.velocity.x<-max_speed)))
			rigidbody2D.AddForce (temp);

		if (rigidbody2D.rotation > 0 && rigidbody2D.rotation < 180)
			rigidbody2D.AddTorque (-torque);
		else
			rigidbody2D.AddTorque (torque);

		setFootSpin (hinge1, speed);
		if (runCount >= 5)
						setFootSpin (hinge2, speed);
						else
						{
						JointMotor2D motor = hinge2.motor;
						motor.motorSpeed = 0;
						hinge2.motor = motor;
						}
	}
	

	void setFootSpin(HingeJoint2D hinge,float speed)
	{

		if (speed > 0) 
		{
			JointMotor2D motor = hinge.motor;
			motor.motorSpeed = footSpeed;
			hinge.motor = motor;
			runCount++;
			
		} 
		else if (speed < 0)
		{
			JointMotor2D motor = hinge.motor;
			motor.motorSpeed = -footSpeed;
			hinge.motor = motor;
			runCount++;
			runCount++;
		}
		else
		{
			runCount=0;
			JointMotor2D motor = hinge.motor;
			motor.motorSpeed = 0;
			hinge.motor = motor;
			runCount++;
		}

	}
}