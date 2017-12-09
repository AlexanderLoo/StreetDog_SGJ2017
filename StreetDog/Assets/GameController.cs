using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;
	//Los siguientes booleanos verifican si se encontró al enemigo determinado	
	public bool chinoLoco;

	void Awake(){

		//Singlenton
		if (instance == null) {
			instance = this;
		}
		else if(instance != this){
			Destroy (gameObject);
		}
	}
}
