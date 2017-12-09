using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidreo : MonoBehaviour {
	public float porcentajeVelocidad;
	public bool unicaVez = false; //El charco te afecta una vez ?
	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player" /*&& !unicaVez*/)
		{
			Walkdog.instance.ActualizarSpeed(porcentajeVelocidad);
			unicaVez = true;
		}
	}
}
