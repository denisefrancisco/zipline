using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Very Important!! //

public class myTimer : MonoBehaviour {

	private Text timerText;		// Reference to Timer's text component
	public float myCoolTimer;	// Counter to keep track of time
	public float totalTraversalTime;	// Var to save total traversal time once timer is stopped
	public float bestTraversalTime;	// Var to save player's best traversal time
	private bool trackingTime; // Flag indicating whether we're keeping track of time or not

	public void StartTimer() {
		// Reset time counter to 0
		myCoolTimer = 0.0f;
		// Start tracking time
		trackingTime = true;
		Debug.Log ("starting timer "+trackingTime+" at time " + myCoolTimer);
	}

	public void StopTimer() {
		// No longer tracking time
		trackingTime = false;
		Debug.Log ("LOST: stopping timer at time " + myCoolTimer);
	}

	public void StopTimerWon() {
		// No longer tracking time
		trackingTime = false;

		// Save current time count as totalTraversalTime
		totalTraversalTime = myCoolTimer; 

		// Calculate best traversal time
		if (bestTraversalTime == 0f) {
			// first time you play, best traversal time is just your first total traversal time
			bestTraversalTime = totalTraversalTime;
		}
		if (totalTraversalTime < bestTraversalTime) {
			bestTraversalTime = totalTraversalTime;
			Debug.Log ("new best time of :" + totalTraversalTime);
		}
		Debug.Log ("WON: stopping timer at time " + totalTraversalTime);
	}

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text>();
		myCoolTimer = 0f;
		totalTraversalTime = 0f;
		bestTraversalTime = 0f;
		trackingTime = false;
	}

	// Update is called once per frame
	void Update () {
		//myCoolTimer += Time.deltaTime;
		//timerText.text = myCoolTimer.ToString ("f2");
		// If we're tracking time, update myCoolTimer counter
		timerText.text = myCoolTimer.ToString ("f2");
		if (trackingTime) {
			myCoolTimer += Time.deltaTime;
		}
	}
}
