﻿using UnityEngine;
using System.Collections;

public class DestroyByLava : MonoBehaviour {
	/* DESCRIPTION: This script is to address the "failing by lava" condition wherein the player drops into the lava and loses. 
	 * MODIFIED: May 7th, 2016
	*/
	public GameObject explosion;
	public AudioClip lavaSound;
	public GameObject lose_panel;

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

	//end of block

	private EdgeCollider2D bc;
	private AudioSource lavaSoundSource;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Avatar");

		setAvatar = GameObject.Find("Avatars").GetComponent<start_play_camera> ();
		reset = GameObject.Find ("enableRebuild").GetComponent<enableRebuild> ();
		snapPoints = GameObject.Find ("Snap Points").GetComponent<ApplySnapPoints> ();
		resetConditions = play_camera.GetComponent<playZip_2> ();
		actions = GameObject.Find ("enableBuilding").GetComponent<enableDrawAndErase> ();
		resetFrames = play_camera.GetComponent<Failures> ();
		respawn = main_camera.GetComponent<start_camera> ();
		player_box = player.GetComponent<removeBoxCollider> ();

		bc = player.GetComponent<EdgeCollider2D> ();
		lavaSoundSource = gameObject.GetComponent<AudioSource> ();

	}

	//	void OnTriggerEnter2D(Collider2D other) {
	//		Debug.Log ("TRIGGERED!");
	//		Instantiate(explosion, transform.position, transform.rotation);
	//		Destroy (gameObject);
	//	}
	void lose() {
//		lose_panel.SetActive (true);	// Activate lose modal
		setAvatar.setAvatarActive();
		reset.ResetAvatar ();
		main_camera.SetActive (true);
		play_camera.SetActive (false);
		player_box.resetBoxCollider ();
		snapPoints.applySnapPoint ();
		resetConditions.resetWinAndLose ();
		actions.EnableBuilding ();
		resetFrames.resetFrameCounter ();
		respawn.respawnAvatar ();
	}

	IEnumerator wait() {
		lavaSoundSource.PlayOneShot (lavaSound, 1);
		destroyObject ();
		yield return new WaitForSeconds (0.85f);
		lose ();
	}

	void destroyObject () {
		Instantiate (explosion, player.transform.position, player.transform.rotation);
		player.SetActive (false);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (bc.IsTouching (gameObject.GetComponent<BoxCollider2D> ())) {
			Debug.Log ("FELL INTO LAVA " + gameObject.name + " - You lose!");
			// Stop timer
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<myTimer> ().StopTimer ();
			// Destroy avatar and activate lose panel
			StartCoroutine (wait ());
		}
	}
}
