using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playZip_2 : MonoBehaviour {

	// Avatar GO's transform component
	public Transform player;
	// These indicate how far the camera will go width-wise to follow the avatar's movement
	public Transform farLeft;
	public Transform farRight;
	// Reference to timer GO displaying zipline traversal time
	public GameObject timer;
	private bool startedTimer;	// Flag indicating when to start the timer
	// Reference to win and lose modal GOs
	public GameObject lose_panel;
	public GameObject win_panel;

	// Use this for initialization
	void Start () {
		startedTimer = false;
	}

	public void resetWinAndLose(){
		timer.SetActive (false);	// Disable timer bc we're returning to build mode
		startedTimer = false;	// Reset startedTimer state
		Debug.Log("playZip2: reset startedTimer state to false");

		// Reset failed state in stagnation Failures script
		gameObject.GetComponent<Failures>().failed = false;	
		Debug.Log ("reset failed state for STAGNATION");

		// Deactivate star GOs representing score in success modal
		GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
		foreach (GameObject s in stars) {
			s.GetComponent<Image>().enabled = false;
		}
		// Deactivate modals
		lose_panel.SetActive (false);
		win_panel.SetActive (false);
		Debug.Log("playZip2: win and lose modals DEACTIVATED");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = player.position.x;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		newPosition.y = player.position.y;
		transform.position = newPosition;

		timer.SetActive (true);	// Activate timer GO

		//if the avatar is past the x coordinate of the first point...start timer.
		if (player.transform.position.x >= -3.2f && !startedTimer) {
			timer.GetComponent<myTimer>().StartTimer(); // Start timer
			startedTimer = true; // Set flag to true so we only call these functions once
		}
	}
}
