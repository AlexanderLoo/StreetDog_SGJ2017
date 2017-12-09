using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borracho : MonoBehaviour {

	private PlayerMovement acceso;
	public int contador;
	public int cantLadridos;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (acceso == null)
			return;

		if (Input.GetKeyDown (KeyCode.Z))
			contador++;

		if (contador >= cantLadridos){
			Destroy (gameObject);
			acceso.miedo = false;

		}
	}

		void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			acceso = PlayerMovement.instance;
			acceso.Miedo (true);
			
		}
	}
}
