using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkdog : MonoBehaviour {

	public float speed;             

	private Rigidbody2D rb2d;
	float movex;
	bool onWater=false;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		movex = 0;
		if (onWater) 
		{
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
			{
				movex = -speed + 1.75f;
			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
			{
				movex = speed - 1.75f;
			}
		} 
		else 
		{
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
			{
				movex = -speed;
			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
			{
				movex = speed;
			}
		}
		print (onWater);
		rb2d.velocity = new Vector2 (movex,rb2d.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "agua") 
		{
			onWater = true;

		}
	
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "agua")
		{
			onWater = false;
		}
	}
}
