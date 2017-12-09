using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watercoll : MonoBehaviour {


	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player") 
		{
			Walkdog.instance.SetWater (true);

		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Walkdog.instance.SetWater (false);
		}
	}
}
