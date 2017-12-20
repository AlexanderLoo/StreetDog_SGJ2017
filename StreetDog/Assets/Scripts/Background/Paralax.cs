using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

	public int capa;

	void Start () {
		GetComponent<SpriteRenderer>().sortingOrder = capa * -100;
	}

	void Update () {
		if (PlayerMovement.instance.rb2d.velocity == Vector2.zero)
			return;

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector3.right* VelocidadParalax()*Time.deltaTime);

		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
		{
			transform.Translate (Vector3.left* VelocidadParalax() *Time.deltaTime);
		}
	}

	public float VelocidadParalax (){
		float _valor = 1/capa;
		return  _valor;
	}
}
