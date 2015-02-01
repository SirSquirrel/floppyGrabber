using UnityEngine;
using System.Collections;

public class DieUnder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject p1 = GameObject.FindGameObjectWithTag("player1");
		GameObject p2 = GameObject.FindGameObjectWithTag("player2");
		
		if(p1.transform.position.y<transform.position.y)
		{
		Ringout(p1);
		}
		else if(p2.transform.position.y<transform.position.y)
		{
		Ringout(p2);
		}
	}
	
	void Ringout(GameObject loser)
	{
	Application.LoadLevel(0);
	}
}
