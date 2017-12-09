﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinoLoco : MonoBehaviour {

	public GameObject cuchillo;
	float elapsed=0;
	public float intervaloDisparo;

	void Update () 
	{
		if (GameController.instance.chinoLoco) {
			elapsed += Time.deltaTime;
			if (elapsed >= intervaloDisparo)
			{
				Instantiate (cuchillo, transform.position, transform.rotation);
				elapsed = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Player")) {

			GameController.instance.chinoLoco = true;
		}
	}
}
