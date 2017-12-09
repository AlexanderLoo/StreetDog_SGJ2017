using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour 
{
	public Transform Player;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
			TrackPlayer ();
	}
	void TrackPlayer()
	{
		float targetX = Player.position.x;
		Vector3 v = new Vector3 (targetX,transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, v, Time.deltaTime * 3f);

	}
}
