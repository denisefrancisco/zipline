using UnityEngine;
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

	//This block of variable initializations refer to the resetting of the avatar after falling into the lava
	private start_play_camera setAvatar;
	private enableRebuild reset;
	private ApplySnapPoints snapPoints;
	private playZip_2 resetConditions;
	private enableDrawAndErase actions;
	private Failures resetFrames;
	private start_camera respawn;
	private removeBoxCollider player_box;

	public GameObject main_camera;
	public GameObject play_camera;
	public GameObject failure_music;

	//end of block


	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		// Set references to collider and script components
		rb = avatar.GetComponent<Rigidbody2D>();
		failed = false;

		setAvatar = GameObject.Find("Avatars").GetComponent<start_play_camera> ();
		reset = GameObject.Find ("enableRebuild").GetComponent<enableRebuild> ();
		snapPoints = GameObject.Find ("Snap Points").GetComponent<ApplySnapPoints> ();
		resetConditions = play_camera.GetComponent<playZip_2> ();
		actions = GameObject.Find ("enableBuilding").GetComponent<enableDrawAndErase> ();
		resetFrames = play_camera.GetComponent<Failures> ();
		respawn = main_camera.GetComponent<start_camera> ();
		player_box = avatar.GetComponent<removeBoxCollider> ();
		Time.timeScale = 0.75f;
	}

	//reset the frame counter after every game is restarted...
	public void resetFrameCounter() {
		frameCounter = 0;
	}

	IEnumerator wait() {
		failure_music.SetActive (true);
		yield return new WaitForSeconds (0.7f);
		avatar.SetActive (false);	// Deactivate avatar GO
		failure_music.SetActive (false);
		setAvatar.setAvatarActive();
		reset.ResetAvatar ();
		main_camera.SetActive (true);
		respawn.returnCamera ();
		play_camera.SetActive (false);
		player_box.resetBoxCollider ();
		snapPoints.applySnapPoint ();
		resetConditions.resetWinAndLose ();
		actions.EnableBuilding ();
		resetFrames.resetFrameCounter ();
		respawn.respawnAvatar ();
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
				if (frameCounter > 100 && !win_panel.activeSelf && !failed && avatar.activeSelf != false) {
					failed = true; // Flag true (so we only do these functions once)
					frameCounter = 0;	// Reset frame counter
					Debug.Log ("STAGNATION - You lose!");
					timerScript = GameObject.FindGameObjectWithTag ("Timer").GetComponent<myTimer> ();
					timerScript.StopTimer ();	// Stop timer
					StartCoroutine(wait());
				}
			}
		}
	}
}
