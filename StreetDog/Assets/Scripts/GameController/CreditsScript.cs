using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour 
{
	public Vector3 pos;
	public float finalPos = 17;

	void Update () 
	{
		if (pos.y >= finalPos) {
			BackToHomeScreen ();
		} else {
			pos = transform.position;
			pos.y = pos.y + 0.015f;
			transform.position = pos;
		}
	}

	void BackToHomeScreen(){

		SceneManager.LoadScene ("HomeScreen");
	}
}
