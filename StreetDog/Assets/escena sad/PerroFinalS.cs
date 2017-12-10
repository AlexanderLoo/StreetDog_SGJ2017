using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class PerroFinalS : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Invoke ("PlayUlti", 1.3f);
		Invoke ("Creditos", 5f);
	}
	public void PlayUlti()
	{
		anim.Play ("chacalonero");
	}
	public void Creditos()
	{
		var wind = new FadeTransition () {
			nextScene = 2,
			duration = 3.2f,

		};
		TransitionKit.instance.transitionWithDelegate (wind);
	}
}
