using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkdog : MonoBehaviour {

	public float speed;             

	private Rigidbody2D rb2d;
	float movex;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		movex = 0;
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
		{
			movex = -speed;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			movex = speed;
		}

		rb2d.velocity = new Vector2 (movex,rb2d.velocity.y);
	}
}
