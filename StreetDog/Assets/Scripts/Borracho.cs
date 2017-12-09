using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borracho : MonoBehaviour {

	private Walkdog acceso;
	public int contador;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (acceso == null)
			return;

		if (Input.GetKeyDown (KeyCode.Space))
			contador++;

		if (contador >= 10){
			Destroy (gameObject);
			acceso.miedo = false;

		}
	}

		void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			acceso = Walkdog.instance;
			acceso.Miedo (true);
			
		}
	}
}
