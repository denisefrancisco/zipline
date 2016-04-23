using UnityEngine;
using System.Collections;

public class Failures : MonoBehaviour {
	//this failure document is only particularly for the stagnation failure, when the avatar gets 
	//stuck on a zipline
	public GameObject avatar;
	public GameObject lose_panel;
	public GameObject win_panel;
	//the rigid body of the player
	private Rigidbody2D rb;
	//in order to make sure the modal doesn't pop up after the 4th/5th restart play, I need to reset 
	//the counter every time the player restarts the game
	private int frameCounter;
	private float speed;


	// Use this for initialization
	void Start () {
		rb = avatar.GetComponent<Rigidbody2D>();
	}
	//reset the frame counter after every game is restarted...
	public void resetFrameCounter() {
		frameCounter = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Grab avatar current speed
		speed = rb.velocity.magnitude;
		//making sure that if the speed of the avatar is less than 0.5f and 
		//the avatar is past the first point of the level. 
		if (speed < 0.5f && avatar.transform.position.x >= -2.8f){
			//increase the frame counter by 1
			frameCounter++;
			//when the frame counter is past a certain amount and the win panel hasn't been 
			//activated, we know the player is "stuck"
			if (frameCounter > 100 && win_panel.activeSelf == false){
				lose_panel.SetActive(true);
				frameCounter = 0;
			}
		}
	
	}
}
