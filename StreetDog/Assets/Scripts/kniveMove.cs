using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kniveMove : MonoBehaviour {

	private Rigidbody2D body;
	//longitud al azar
	public Vector2 randomDistance;
	//altura al azar
	public Vector2 randomHeight;
	float elapsed;

	void Awake () 
	{
		body = GetComponent<Rigidbody2D> ();
	}
	void Start()
	{
		float speedx = Random.Range (randomDistance.x, randomDistance.y);
		float speedy = Random.Range (randomHeight.x, randomHeight.y);
		body.AddTorque (speedx*100);
		body.velocity = new Vector2 (-speedx, speedy*3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsed += Time.deltaTime;
		if (elapsed >= 3) 
		{
			Destroy (gameObject);
		}
	}
}
