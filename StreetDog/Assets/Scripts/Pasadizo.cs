using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasadizo : MonoBehaviour {

	public Animator playerAnim;
	public GameObject capaActual;
	public GameObject capaSiguiente;
	void OnTriggerStay2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				playerAnim.SetTrigger ("ChangeLayer");
				Invoke ("CambiarCapas", 1);
			}
		}
	}
	void CambiarCapas()
	{
		capaActual.SetActive(false);
		capaSiguiente.SetActive(true);
		
	}
}
