using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

	public int capa;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sortingOrder = capa * -100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector3.right* (10-capa)*Time.deltaTime);

		}
			
	}
}
