﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* This failure document is only particularly for the  
stagnation failure, when the avatar gets stuck on a zipline */
public class Failures : MonoBehaviour {

	public GameObject avatar;	// avatar GO
	public GameObject lose_panel;	// Lose modal
	public GameObject win_panel;	// Win modal
	private Rigidbody2D rb;	// Reference to avatar's rigidbody component
	public bool failed;	// Flag indicating player has failed
	private myTimer timerScript; 	// Reference to timer GO script component
	//in order to make sure the modal doesn't pop up after the 4th/5th restart play, I need to reset 
	//the counter every time the player restarts the game
	public int frameCounter;
	private float speed;	// Avatar's speed


	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		// Set references to collider and script components
		rb = avatar.GetComponent<Rigidbody2D>();
		failed = false;
	}

	//reset the frame counter after every game is restarted...
	public void resetFrameCounter() {
		frameCounter = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Reset failed state when lose modal is disabled
		if (!avatar.activeSelf && failed) {
			failed = false;
			frameCounter = 0;
		}

		// If avatar GO exists
		if (avatar != null) {
			// Grab avatar current speed
			speed = rb.velocity.magnitude;

			/* As long as avatar's speed is slow enough (less than 0.5f) and 
			the avatar is past the first point of the level...*/
			if (speed < 0.5f && avatar.transform.position.x >= -2.8f) {
				frameCounter++;	// Increment frame counter
				/* When we've waited long enough (more than 100 frames) and neither
				 modal has been activated yet, the player must be "stuck"*/
				if (frameCounter > 125 && !win_panel.activeSelf && !failed && avatar.activeSelf != false) {
					failed = true; // Flag true (so we only do these functions once)
					frameCounter = 0;	// Reset frame counter
					avatar.SetActive (false);	// Deactivate avatar GO
					Debug.Log ("STAGNATION - You lose!");
					timerScript = GameObject.FindGameObjectWithTag ("Timer").GetComponent<myTimer> ();
					timerScript.StopTimer ();	// Stop timer
					lose_panel.SetActive (true);		// Activate lose modal
				}
			}
		}
	}
}
