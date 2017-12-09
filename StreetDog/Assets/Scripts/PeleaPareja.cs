using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeleaPareja : MonoBehaviour {

	//Lista pública de los posibles objetos que se pueden lanzar
	public GameObject[] objects;

	float elapsed=0;
	public float intervaloDisparo;

	void Update () 
	{
		if (GameController.instance.peleaPareja) {
			elapsed += Time.deltaTime;
			if (elapsed >= intervaloDisparo)
			{
				GameObject _objeto = Instantiate (objects[Random.Range(0,objects.Length)], transform.position, transform.rotation);
				_objeto.transform.SetParent(transform);
				elapsed = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Player")) {

			GameController.instance.peleaPareja = true;
		}
	}
}
