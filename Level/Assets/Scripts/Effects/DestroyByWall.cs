﻿using UnityEngine;
using System.Collections;

public class DestroyByWall : MonoBehaviour {

	public GameObject explosion;
	public AudioClip explosionSound;
	private AudioSource explosion_source;
	public GameObject player;
	public GameObject lose_panel;
	private EdgeCollider2D bc;
	// Use this for initialization
	void Start () {
		bc = player.GetComponent<EdgeCollider2D> ();
		explosion_source = gameObject.GetComponent<AudioSource> ();

	}

//	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log ("TRIGGERED!");
//		Instantiate(explosion, transform.position, transform.rotation);
//		Destroy (gameObject);
//	}
	void lose() {
		lose_panel.SetActive (true);
	}

	IEnumerator wait() {
		explosion_source.PlayOneShot (explosionSound, 1);
		destroyObject ();
		yield return new WaitForSeconds (1.0f);
		lose ();
	}

	void destroyObject () {
		Instantiate (explosion, player.transform.position, player.transform.rotation);
		player.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (bc.IsTouching(gameObject.GetComponent<BoxCollider2D>())) {
			Debug.Log ("RAN INTO WALL " + gameObject.name + " - You lose!");
			// Stop timer
			GameObject.FindGameObjectWithTag("Timer").GetComponent<myTimer>().StopTimer();
			// Destroy avatar and activate lose panel
			StartCoroutine (wait ());
		}
	}
}
