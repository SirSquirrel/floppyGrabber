using UnityEngine;
using System.Collections;

public class DieAfterTime : MonoBehaviour {

	public int frameLife = 120;
	private int frameCounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		frameCounter += 1;

				Destroy(gameObject);
		}

}
