using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkdog : MonoBehaviour {


	public float speed;             

	private Rigidbody2D rb2d;
	float movex;
	bool onWater=false;
	public static walkdog instance;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		instance = this;
	}
	void Start()
	{

	}

	void FixedUpdate()
	{
		movex = 0;

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			if (onWater) 
			{
				movex = -speed + 1.75f;
			}
			else
				movex = -speed;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
		{
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
