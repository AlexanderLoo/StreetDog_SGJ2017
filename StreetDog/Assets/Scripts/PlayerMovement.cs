﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private SpriteRenderer sr;
	private Rigidbody2D rb2d;
	public static PlayerMovement instance;

	public GameObject ladrido;//Esto solo será un sonido. no creara un GameObject
	public Transform posBoca;

	public Vector2 gameLimits;
	public float speed;    
	public float jumpForce;
	public bool miedo = false;         
	float movex;
	bool onWater=false;
	bool isGrounded;
	bool jumping = false;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		instance = this;
	}

	void Start()
	{
		miedo = false;
	}

	void Update(){

		//Establecemos los límites del juego
		Vector3 newPos = transform.position;
		newPos.x = Mathf.Clamp (transform.position.x, gameLimits.x, gameLimits.y);
		transform.position = newPos;

		if (Input.GetKeyDown (KeyCode.Z))
			Ladrar();

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

			rb2d.AddForce (Vector2.up * jumpForce);
			isGrounded = false;
		}
	}
	//Detectamos si aterrizó en el piso
	void OnCollisionEnter2D(Collision2D col){

		if (col.collider.CompareTag("Floor")) {
			isGrounded = true;
		}
	}

	void FixedUpdate()
	{
		if (miedo)
		{
			rb2d.velocity = Vector2.zero;
			return;
		}

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


			posBoca.localPosition = new Vector3 (-2.75f,0.9f,0f);
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

			posBoca.localPosition = new Vector3 (2.75f,0.9f,0f);

		}
		rb2d.velocity = new Vector2 (movex,rb2d.velocity.y);

		if (rb2d.velocity == Vector2.zero)
			posBoca.localPosition = new Vector3 (1.25f,0.9f,0f);
	}

	public void SetWater(bool agua)
	{
		onWater = agua;
	}

	public void ActualizarSpeed (float _valor)
	{
		speed *= _valor;
	}

	public void Ladrar ()
	{
		Destroy (Instantiate(ladrido,posBoca.position,transform.rotation),1f);
	}

	public void Miedo (bool _valor)
	{
		miedo = _valor;
	}
}