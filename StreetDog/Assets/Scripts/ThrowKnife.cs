using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnife : MonoBehaviour {

	// Use this for initialization
	public GameObject cuchillo;
	float elapsed=0;
	public float intervaloDisparo;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsed += Time.deltaTime;
		if (elapsed >= intervaloDisparo)
		{
			Instantiate (cuchillo, transform.position, transform.rotation);
			elapsed = 0;
		}
	}
}
