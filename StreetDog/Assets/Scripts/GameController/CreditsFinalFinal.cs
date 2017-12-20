 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class CreditsFinalFinal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			/*var wind = new FadeTransition () {
				nextScene = 3,
				duration = 1f,

			};
			TransitionKit.instance.transitionWithDelegate (wind);*/
			SceneManager.LoadScene(3);
		}
	}
}
