using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float p1Max;
	public float p1MaxHead;
	
	public float p2Max;
	public float p2MaxHead;
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake()
	{
	GameObject p1 = GameObject.FindGameObjectWithTag("player1");
	GameObject p2 = GameObject.FindGameObjectWithTag("player2");
	
	DamageControlScript P1ChestStats = p1.GetComponent<DamageControlScript>();
		p1Max = P1ChestStats.health;
		
	DamageControlScript P2ChestStats = p2.GetComponent<DamageControlScript>();
		p2Max = P2ChestStats.health;
	
	DamageControlScript P1HeadStats = p1.transform.FindChild("face").gameObject.GetComponent<DamageControlScript>();
		p1MaxHead = P1HeadStats.health;
		
	DamageControlScript P2HeadStats = p2.transform.FindChild("face").gameObject.GetComponent<DamageControlScript>();
		p2MaxHead = P2HeadStats.health;
	
	
	}
	
	// Update is called once per frame
	void OnGUI() {
		GameObject p1 = GameObject.FindGameObjectWithTag("player1");
		GameObject p2 = GameObject.FindGameObjectWithTag("player2");
		
		DamageControlScript P1ChestStats = p1.GetComponent<DamageControlScript>();
		GUI.Box(new Rect(8, 12, P1ChestStats.health/4, 64), (int)P1ChestStats.health + "/" + p1Max);
		
		DamageControlScript P2ChestStats = p2.GetComponent<DamageControlScript>();
		GUI.Box(new Rect(Screen.width - P2ChestStats.health/4, 12, P2ChestStats.health/4, 64), (int)P2ChestStats.health + "/" + p2Max);
		
		DamageControlScript P1HeadStats = p1.transform.FindChild("face").gameObject.GetComponent<DamageControlScript>();
		GUI.Box(new Rect(8, 88, P1HeadStats.health/4, 64), (int)P1HeadStats.health + "/" + p1MaxHead);
		
		DamageControlScript P2HeadStats = p2.transform.FindChild("face").gameObject.GetComponent<DamageControlScript>();
		GUI.Box(new Rect(Screen.width - P2ChestStats.health/4, 72, P2HeadStats.health/4, 64), (int)P2HeadStats.health + "/" + p1MaxHead);
	}
}
