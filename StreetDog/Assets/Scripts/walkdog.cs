using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkdog : MonoBehaviour {


	public float speed;             

	private SpriteRenderer sr;
	private Rigidbody2D rb2d;
	private 
	float movex;
	bool onWater=false;
	public static walkdog instance;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		instance = this;
	}

	void FixedUpdate()
	{
		movex = 0;

		//Si nos movemos a la izquierda flipeamos el sprite para que mire hacia la izquierda
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			sr.flipX = true;

			//Si tocamos el charco reducimos la velocidad
			if (onWater) 
			{
				movex = -speed + 1.75f;
				//movex = -speed * 0.75f;(otra opción)
			}
			else
				movex = -speed;
		}
		//Misma lógica que la anterior pero hacia el otro lado
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
		{
			sr.flipX = false;
			if (onWater) 
			{
				movex = speed - 1.75f;
			} 
			else 
			{
				movex = speed;
			}
		}




		rb2d.velocity = new Vector2 (movex,rb2d.velocity.y);
	}
	public void setWater(bool agua)
	{
		onWater = agua;
	}


}
