﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercoll : MonoBehaviour {


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
