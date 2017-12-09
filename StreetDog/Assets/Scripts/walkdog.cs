using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkdog : MonoBehaviour {

	public float speed;             

	private Rigidbody2D rb2d;
	float movex;
	// Use this for initialization
	void Start()
	{
		
		rb2d = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{
		movex = 0;
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			movex = -3f;
			transform.localScale = new Vector3 (-4f, 4f, 1f);

		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			movex = 3f;
			transform.localScale = new Vector3 (4f, 4f, 1f);
		}
		rb2d.velocity = new Vector2 (movex,rb2d.velocity.y);
	}
}
