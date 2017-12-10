using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour 
{

	// Use this for initialization
	Vector3 pos;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos = transform.position;
		pos.y = pos.y + 0.015f;
		transform.position = pos;
	}
}
