using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rb;

	void Awake(){

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}


	void Update(){

		anim.SetFloat ("Walk", Mathf.Abs(rb.velocity.x));
	}

}
