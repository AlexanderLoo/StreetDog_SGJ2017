using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour {

	private Rigidbody2D body;
	public float speedx = 4;
	public float porcentajeVelocidad;
	public Vector2 randomHeight;

	float elapsed;

	void Awake () 
	{
		body = GetComponent<Rigidbody2D> ();
	}
	void Start()
	{

		float speedy = Random.Range (randomHeight.x, randomHeight.y);
		body.AddTorque (speedx*100);
		//variable random para definir que dirección va ir derecha o izquierda

		int randomDir = Random.Range(-1,2);
		body.velocity = new Vector2 (speedx * randomDir, speedy*3);
	}

	void Update () 
	{
		elapsed += Time.deltaTime;
		if (elapsed >= 3) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player")
		{
			PlayerMovement.instance.ActualizarSpeed(porcentajeVelocidad);
		}
	}
}
