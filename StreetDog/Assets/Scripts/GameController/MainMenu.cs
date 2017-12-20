using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;


public class MainMenu : MonoBehaviour {

	public void OnClickPlay()
	{
		Debug.Log ("go to play");
		//SceneManager.LoadScene ("level1");
		/*var wind = new PixelateTransition()
		{
			nextScene = 1,
			duration = 1.4f,

		};
		TransitionKit.instance.transitionWithDelegate( wind );*/
		SceneManager.LoadScene(1);
	}
	public void onClickExit()
	{
		Application.Quit ();
	}
	public void onClickCredits()
	{
		/*var anima = new  RippleTransition () 
		{
			nextScene = 2,
			duration = 1.4f,
		};
		TransitionKit.instance.transitionWithDelegate(anima);*/
		SceneManager.LoadScene(2);
	}

}
