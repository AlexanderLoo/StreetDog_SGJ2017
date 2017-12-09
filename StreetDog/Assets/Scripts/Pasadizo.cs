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
		if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))&& accionable) {
				playerAnim.SetTrigger ("ChangeLayer");
				Invoke ("CambiarCapas", 1);
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
		capaActual.SetActive(false);
		capaSiguiente.SetActive(true);
		
	}
}
