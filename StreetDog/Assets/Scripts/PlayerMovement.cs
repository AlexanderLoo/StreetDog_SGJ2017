using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private SpriteRenderer sr;
	public Rigidbody2D rb2d;
	private Animator anim;
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
	public bool pasadizo = false;
	public bool puedeLadrar;
	int estadomovimiento=1;
	public int borracho;

	public float tiempo;
	public bool isHurt;
	private float targetAlpha;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		instance = this;
	}

	void Start()
	{
		miedo = false;
		pasadizo = false;
		puedeLadrar = true;
	}

	void Update(){
		//Establecemos los límites del juego
		Vector3 newPos = transform.position;
		newPos.x = Mathf.Clamp (transform.position.x, gameLimits.x, gameLimits.y);
		transform.position = newPos;

		if (Input.GetKeyDown (KeyCode.E)||Input.GetKeyDown (KeyCode.G)||Input.GetKeyDown (KeyCode.B))
			Ladrar();

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
			anim.SetTrigger ("Jump");
			rb2d.AddForce (Vector2.up * jumpForce);
			isGrounded = false;
		}
		anim.SetFloat ("Walk", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool ("isGrounded", isGrounded);
		ManageBlinking ();
	}
	//Detectamos si aterrizó en el piso
	void OnCollisionEnter2D(Collision2D col){

		if (col.collider.CompareTag("Floor")) {
			isGrounded = true;
		}
	}
	public int GetEstado()
	{
		return estadomovimiento;
	}

	void FixedUpdate()
	{
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A) ||Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.D) ) 
		{
			estadomovimiento = 1;
		}
		if (miedo||pasadizo)
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

			estadomovimiento = 2;
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

			estadomovimiento = 3;
			posBoca.localPosition = new Vector3 (2.75f,0.9f,0f);

		}
		rb2d.velocity = new Vector2 (movex,rb2d.velocity.y);

		if (rb2d.velocity == Vector2.zero)
			posBoca.localPosition = new Vector3 (1.25f,0.9f,0f);
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A) ||Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.D) ) 
		{
			estadomovimiento = 1;
		}
	}

	public void SetWater(bool agua)
	{
		onWater = agua;
	}

	public void ActualizarSpeed (float _valor)
	{
		speed *= _valor;

		if (speed <= 1 )
			speed = 1;

		if (_valor >=1)
			return;
			
		isHurt = true;
		Invoke ("IsNotHurt", 2);
	}

	public void Ladrar ()
	{	
		if (!puedeLadrar)
			return;

		StartCoroutine(RepetirLadrido());
		puedeLadrar = false;
		
			
	}

	IEnumerator RepetirLadrido (){
		yield return new WaitForSeconds (0.2f);
		Destroy ( Instantiate(ladrido,posBoca.position,transform.rotation),0.5f);
		borracho++;
		puedeLadrar = true;

	}

	public void Miedo (bool _valor)
	{
		miedo = _valor;
	}
	//Función que sirve como feedback al colisionar con un hazard
	void ManageBlinking(){

		if (isHurt) {
			Color newColor = sr.color;
			//Mathf.Lerp sirve para recorrer de forma gradual
			//Mathf.Lerp(origen,destino,velocidad)
			newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);
			if (newColor.a < 0.05f) {
				targetAlpha = 1;
			}
			if (newColor.a > 0.95f) {
				targetAlpha = 0;
			}
			sr.color = newColor;
		} else {
			sr.color = Color.white;
		}	
	}
	//Función para volver al estado no lastimado
	void IsNotHurt(){
		isHurt = false;
	}
}
