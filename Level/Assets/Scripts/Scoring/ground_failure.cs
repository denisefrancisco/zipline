using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ground_failure : MonoBehaviour {

	public GameObject playCamera;	// play Camera GO
	public GameObject avatar;	// Avatar GO
	public GameObject lose_modal;	// Lose modal GO
	private EdgeCollider2D ec;	// Avatar's edge collider
	private BoxCollider2D bc;	// Reference to floor's box collider component
	private bool failed;	// Flag indicating player has failed
	private myTimer timerScript; 	// Reference to timer GO script component

	// Use this for initialization
	void Start () {
		// Set references to collider and script components
		bc = gameObject.GetComponent<BoxCollider2D> ();
		ec = avatar.GetComponent<EdgeCollider2D> ();
		failed = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Reset failed state when lose modal is disabled
		if (!playCamera.activeSelf && failed) {
			failed = false;
			Debug.Log ("reset failed state for GROUND FAILURE");
		}

		// If the avatar's collider and floor's collider are touching eachother, player has failed
		if (bc.IsTouching(ec) && !failed) {
			Debug.Log ("TOUCHED GROUND "+ gameObject.name + " - You lose!");
			failed = true;	// Flag true (so we only do these functions once)
			timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<myTimer>();
			timerScript.StopTimer();	// Stop timer
			lose_modal.SetActive(true);	// Activate lose modal
			avatar.SetActive (false);	// Deactivate avatar GO
			Time.timeScale = 0.0f;
		}
	}
	
}

