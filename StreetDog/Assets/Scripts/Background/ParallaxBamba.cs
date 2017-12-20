using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBamba : MonoBehaviour
{

	public float speed = 0.5f;
	int estado;

	void Update () 
	{
		
		switch(PlayerMovement.instance.GetEstado())
		{
			
			case 1:
			{
				//Vector2 offset = new Vector2 (0, 0);
				//GetComponent<Renderer> ().material.mainTextureOffset = offset;
				break;
			}
			case 2:
			{
				Vector2 offset = new Vector2 (Time.time * speed, 0);
				GetComponent<Renderer> ().material.mainTextureOffset = offset;
				break;
			}
			case 3:
			{
				Vector2 offset = new Vector2 (Time.time * -speed, 0);
				GetComponent<Renderer> ().material.mainTextureOffset = offset;
				break;
			}
		}
		print (PlayerMovement.instance.GetEstado());
	}
}
