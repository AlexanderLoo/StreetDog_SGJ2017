using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasadizo : MonoBehaviour {

	public Animator playerAnim;
	public GameObject capaActual;
	public GameObject capaSiguiente;
	private bool accionable = false;

	void Update()
	{
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))&& accionable && !PlayerMovement.instance.pasadizo) {
				playerAnim.SetTrigger ("ChangeLayer");
				Invoke ("CambiarCapas", 1.3f);
				PlayerMovement.instance.pasadizo=true;
				PlayerMovement.instance.ActualizarSpeed(1.2f);
			}
	}
	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			accionable=true;
		}
	}

	void OnTriggerExit2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			accionable=false;
		}
	}
	void CambiarCapas()
	{
		PlayerMovement.instance.pasadizo=false; 
		capaActual.SetActive(false);
		capaSiguiente.SetActive(true);
		
	}
}
