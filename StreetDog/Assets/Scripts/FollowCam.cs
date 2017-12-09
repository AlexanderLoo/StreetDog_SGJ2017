using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour 
{
	public Transform Player;
	public float followSpeed;
	//Esta variable ayuda a posicionar bien la cámara
	public float offset;

	void Update ()
	{
		TrackPlayer ();
	}
	//Función para seguir al player 
	void TrackPlayer()
	{
		float targetX = Player.position.x + offset;
		Vector3 v = new Vector3 (targetX,transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, v, Time.deltaTime * followSpeed);
	}
}
