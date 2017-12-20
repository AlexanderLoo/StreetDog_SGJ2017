using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player") 
		{
			PlayerMovement.instance.SetWater (true);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			PlayerMovement.instance.SetWater (false);
		}
	}
}
