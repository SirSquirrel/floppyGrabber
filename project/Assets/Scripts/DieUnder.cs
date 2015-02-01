using UnityEngine;
using System.Collections;

public class DieUnder : MonoBehaviour {

	private bool ended = false;
	private float endTimer = 0;
	public Transform p1Win;
	public Transform p2Win;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject p1 = GameObject.FindGameObjectWithTag("player1");
		GameObject p2 = GameObject.FindGameObjectWithTag("player2");
		
		if(p1.transform.position.y<transform.position.y && ended == false)
		{
			endTimer = Time.time + 1;
			ended = true;
			Object.Instantiate(p2Win, new Vector3(0,0,0), transform.rotation);
		}
		
		else if(p2.transform.position.y<transform.position.y && ended == false)
		{
			endTimer = Time.time + 1;
			ended = true;
			Object.Instantiate(p1Win, new Vector3(0,0,0), transform.rotation);
		}
		
		if(ended == true && Time.time>endTimer)
		{
			Application.LoadLevel(0);
		}
	}
		
	
}
