using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Script checks if the player touches fire at all
public class fire_failure : MonoBehaviour {

	public GameObject playCamera; 	// play camera GO
	public GameObject player;	// Avatar GO
	public GameObject lose_panel;	// Lose modal
	private EdgeCollider2D ec;	// Avatar's edge collider
	private CircleCollider2D cc;	// Fire GO's circle collider
	private bool failed;	// Flag indicating player has failed
	private myTimer timerScript;	// Reference to timer GO script component

	// Use this for initialization
	void Start () {
		// Set references to collider and script components
		cc = gameObject.GetComponent<CircleCollider2D> ();
		ec = player.GetComponent<EdgeCollider2D> ();
		failed = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Reset failed state when play camera is disabled
		if (!playCamera.activeSelf && failed) {
			failed = false;
		}

		// If the avatar's collider and fire's collider are touching eachother, player has failed
		if (cc.IsTouching(ec) && !failed) {
			Debug.Log ("TOUCHED FIRE" + gameObject.name + " - You lose!");
			failed = true;	// Flag true (so we only do these functions once)
			timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<myTimer>();
			timerScript.StopTimer();	// Stop timer
			lose_panel.SetActive (true);	// Activate lose modal
			player.SetActive (false);	// Deactivate avatar GO
			Time.timeScale = 0f;
		}
	}
}
