using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borracho : MonoBehaviour {

	private PlayerMovement acceso;
	public int contador;
	public int cantLadridos;

	void Update () {
		if (acceso == null)
			return;
	
		if (acceso.borracho >= cantLadridos){
			Destroy (gameObject);
			acceso.miedo = false;
		}
	}

		void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			acceso = PlayerMovement.instance;
			acceso.borracho = 0;
			acceso.Miedo (true);
		}
	}
}
