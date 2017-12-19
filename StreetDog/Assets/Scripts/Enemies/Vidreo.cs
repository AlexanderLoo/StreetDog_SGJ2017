using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidreo : MonoBehaviour {
	public float porcentajeVelocidad;
	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			PlayerMovement.instance.ActualizarSpeed(porcentajeVelocidad);
		}
	}
}
