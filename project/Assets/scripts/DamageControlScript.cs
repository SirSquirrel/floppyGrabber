using UnityEngine;
using System.Collections;

public class DamageControlScript : gettinHit {

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		renderer.material.color = Color.white;
	if(health<=0)
	{
	lose ();
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


	void lose()
	{
	Application.LoadLevel(0);
	}
}
