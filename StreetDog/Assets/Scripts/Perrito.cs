using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perrito : MonoBehaviour {

	private AudioSource audioS;

	void Start(){

		audioS = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Player")) {

			audioS.enabled = true;
		}
	}
}
