﻿using UnityEngine;
using System.Collections;

public class animOnButton : MonoBehaviour {


	/*Variable 'go' will be used later as a force added to the rb to propel 
			*him in x position animation.
		*The 'movement_sp' float is used as a reference to speed. If the animation
			*is moving too slowly increase this variable.
		*The first Collider named 'feet' is the name of the box collider that 
			*must be on the avatar.
		*The next Collider named origin is the collider that the avatar
			*begins on before zip lining.
		*/

	public GameObject avatar;
	public Animator anim;



	private bool go = false;
	private float movement_sp = 2.05f;
	private Collider2D feet;
	public Collider2D origin;
	private Rigidbody2D rb;

// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		feet = GetComponent<BoxCollider2D> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	//Use this for what happens when the button is clicked.
	public void OnClick() {

		//There is a trigger called "onClick" in the animator's parameters. 
		anim.SetTrigger ("onClick");
		go = true;
	}
	//The avatar progresses to jump animation.
	void OnTriggerEnter2D (Collider2D other) {
	
		anim.SetTrigger ("onZip");
	
	}
	//Update is called once per frame.
	void Update () {
		if (go) {

		/* The 'if' statement checks to see if the player is currently on the piece of furniture.
			*  if he is, he will keep moving forward, if not he will recieve a force to
			*  push him on the zip line initially.
			*/


			if (feet.IsTouching (origin)) { 				
				rb.AddForce (Vector3.right * movement_sp, ForceMode2D.Impulse);
			}
		}
	}
}

