using UnityEngine;
using System.Collections;

public class ItemBreak : MonoBehaviour {

	public Transform shard;

	public float shardSpeed = 1f;

	public AudioSource breakSound;
	public AudioClip sound;

	public float breakParameter = 1f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		float force = this.rigidbody2D.velocity.magnitude + collision.gameObject.rigidbody2D.velocity.magnitude;
		print (force);
		if(force > breakParameter)
		{
			for(int i = 1; i <= 5; i++)
			{
				int randomForce = Random.Range(70,400);
				Transform shardPart = (Transform)Instantiate (shard, transform.position, Quaternion.Euler(0, 0, (72*i)));
				shardPart.rigidbody2D.AddForce(shardPart.transform.right * randomForce * force * shardSpeed);
				shardPart.rigidbody2D.AddTorque((float)randomForce / 3);
			}
			//breakSound.PlayOneShot(sound, 0.8f);
			AudioSource.PlayClipAtPoint(sound, transform.position);
			Destroy(this.gameObject);
		}
	}
}
