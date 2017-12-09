using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasadizo : MonoBehaviour {
	public GameObject capaActual;
	public GameObject capaSiguiente;
	void OnTriggerStay2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
				CambiarCapas();
		}
	}
	public void CambiarCapas()
	{
		capaActual.SetActive(false);
		capaSiguiente.SetActive(true);
		
	}
}
