using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	//Los siguientes booleanos verifican si se encontró al enemigo determinado	
	public Transform player;
	public bool chinoLoco, peleaPareja;
	public Image[] motherHeartSprite;
	public Image[] childHearthSprite;
	//Variable que muestra el tiempo antes que el cachorro muera
	public Text countDownText;
	private float countDown, finalCountDown;
	//booleano que muestra el estado final del juego
	public bool finish;

	//Valores a llegar para cambiar el estado del corazón
	public float checkTime = 20;
	private float checkPoint = 100;
	//Indices actuales de las listas 
	private int motherIndex = 0;
	private int childrenIndex = 0;
	float targetAlpha;

	void Awake(){

		//Singlenton
		if (instance == null) {
			instance = this;
		}
		else if(instance != this){
			Destroy (gameObject);
		}
	}
	void Start(){

		finalCountDown = checkTime * childHearthSprite.Length;
		countDown = finalCountDown;
	}
	void Update(){

		MotherHeart ();
		ChildHeart ();
		ShowCountDown ();
		ManageBlinking ();

	}
	//Función que actualiza el corazón de la madre
	void MotherHeart(){
		if (motherIndex <= motherHeartSprite.Length) {
			if (player.position.x > checkPoint) {
				motherHeartSprite [motherIndex].enabled = false;
				motherHeartSprite [motherIndex+1].enabled = true;
				motherIndex += 1;
				checkPoint += 100;
			}
		}

	}
	//Función que actualiza el corazón del hijo
	void ChildHeart(){

		if (childrenIndex < childHearthSprite.Length-1) {
			if (Time.time > checkTime) {
				childHearthSprite [childrenIndex].enabled = false;
				
				childHearthSprite [childrenIndex+1].enabled = true;
				
					
				childrenIndex += 1;
				checkTime += 20;
			}
		}
	}
	//Función que muestra el contador del corazón del cachorro
	void ShowCountDown(){
		if (countDown<=0){
			countDown=0;
			return;
		}

		int minutos;
		int segundos;
		countDown -= Time.deltaTime;
		if (countDown > 60) {
			minutos = Mathf.RoundToInt (countDown) / 60;
			segundos = Mathf.RoundToInt(countDown) - 60;
		} else {
			minutos = 0;
			segundos = Mathf.RoundToInt(countDown);
		}
		if (segundos < 10) {

			countDownText.text = "0" + minutos.ToString () + ":" + "0" + segundos.ToString ();
		} else {
			countDownText.text = "0" + minutos.ToString () + ":" + segundos.ToString ();
		}
	}

	void ManageBlinking(){

		foreach (Image sprite in motherHeartSprite) {
			
		if (PlayerMovement.instance.isHurt) {
				Color newColor = sprite.color;
				newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);

				if (newColor.a < 0.05f) {
					targetAlpha = 1;
				}
				if (newColor.a > 0.95f) {
					targetAlpha = 0;
				}
				sprite.color = newColor;
			}else {
				sprite.color = Color.white;
			}
		}	
	}
}
