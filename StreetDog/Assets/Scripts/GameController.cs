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

	public float checkTime = 20;
	private float checkPoint = 100;
	//Indices actuales de las listas 
	private int motherIndex = 0;
	private int childrenIndex = 0;

	void Awake(){

		//Singlenton
		if (instance == null) {
			instance = this;
		}
		else if(instance != this){
			Destroy (gameObject);
		}
	}

	void Update(){


	}
	//Función que actualiza el corazón de la madre
	void MotherHeart(){

		if (transform.position.x > checkPoint) {
			motherHeartSprite [motherIndex].enabled = false;
			motherIndex += 1;
			motherHeartSprite [motherIndex].enabled = true;
			checkPoint += 100;
		}
	}
	//Función que actualiza el corazón del hijo
	void ChildHeart(){

		if (Time.time > checkTime) {
			childHearthSprite [childrenIndex].enabled = false;
			childrenIndex += 1;
			childHearthSprite [childrenIndex].enabled = true;
			checkTime = 0;
		}
	}



}
