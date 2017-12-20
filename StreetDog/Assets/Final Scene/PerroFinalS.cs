using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class PerroFinalS : MonoBehaviour {


	Animator anim;
	public Text mensaje;

	void Start () {
		anim = GetComponent<Animator> ();
		Invoke ("PlayUlti", 1.3f);
		Invoke ("ShowText", 7);
		Invoke ("Creditos",14);
	}
	public void PlayUlti()
	{
		anim.Play ("chacalonero");
	}
	public void Creditos()
	{
		/*var wind = new FadeTransition () {
			nextScene = 2,
			duration = 3.2f,

		};
		TransitionKit.instance.transitionWithDelegate (wind);*/
		SceneManager.LoadScene(2);
	}

	void ShowText(){
		
		mensaje.enabled = true;
	}
}
