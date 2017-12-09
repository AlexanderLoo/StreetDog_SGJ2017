using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kniveMove : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D body;
	public float speedx;
	public float speedy;
	float elapsed;
	void Awake () 
	{
		body = GetComponent<Rigidbody2D> ();
	}
	void Start()
	{
		body.AddTorque (speedx*100);
		body.velocity = new Vector2 (-speedx, speedy*3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsed += Time.deltaTime;
		if (elapsed >= 2) 
		{
			Destroy (gameObject);
		}
	}
}
