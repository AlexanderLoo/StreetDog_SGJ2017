using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player") 
		{
			walkdog.instance.setWater (true);

		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			walkdog.instance.setWater (false);
		}
	}
}
