using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnivesThrow : MonoBehaviour {

	private Rigidbody2D body;
	//longitud al azar
	public Vector2 randomDistance;
	//altura al azar
	public Vector2 randomHeight;
	float elapsed;
	public float intervaloDisparo;


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

	void Update () 
	{
		elapsed += Time.deltaTime;
		if (elapsed >= 3) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			GameController.instance.peleaPareja = true;	
			PlayerMovement.instance.ActualizarSpeed (0.91f);
		}
	}
}
