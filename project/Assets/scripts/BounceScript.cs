using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
		{
			if(collision.gameObject.transform.parent!= null)
			{
				findTopParent(collision.gameObject).rigidbody2D.velocity = new Vector2(findTopParent(collision.gameObject).rigidbody2D.velocity.x,50);
			}
			else
			{
				collision.gameObject.rigidbody2D.velocity = new Vector2(collision.gameObject.rigidbody2D.velocity.x,50);
			}
		}
	}
	
	public GameObject findTopParent(GameObject startobject)
	{
	if(startobject.transform.parent == null)
	{
		return startobject;
	}
	else{
	return findTopParent(startobject.transform.parent.gameObject);
	}
	}
}
