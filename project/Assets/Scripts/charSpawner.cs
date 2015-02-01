using UnityEngine;
using System.Collections;

public class charSpawner : MonoBehaviour {

	public int charselected;
	public GameObject character0;
	public GameObject character1;
	public GameObject character0p2;
	public GameObject character1p2;
	
	// Use this for initialization
	void Start () {
	
	//get charSelected
	if(charselected == 0)
	{
		if(gameObject.layer == 8)
		{
				Object.Instantiate(character0, transform.position, transform.rotation);
		}
		
		if(gameObject.layer == 9)
		{
				Object.Instantiate(character0p2, transform.position, transform.rotation);
			
		}
	}
	
	else if(charselected == 1)
	{
		if(gameObject.layer == 8)
		{
				Object.Instantiate(character1, transform.position, transform.rotation);
		}
		
		if(gameObject.layer == 9)
		{
			Object.Instantiate(character1p2, transform.position, transform.rotation);
		}
	}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
