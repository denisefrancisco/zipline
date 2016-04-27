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
		myCoolTimer = 0f;
		// Start tracking time
		trackingTime = true;
		Debug.Log ("starting timer "+trackingTime+" at time " + myCoolTimer);
	}

	public void StopTimer() {
		// No longer tracking time
		trackingTime = false;
		// Save current time count as totalTraversal 
		totalTraversalTime = myCoolTimer; 
		Debug.Log ("stopping timer "+trackingTime+" at time " + totalTraversalTime);
	}

	public void DisplayTimer() {
		timerText.enabled = true;
		Debug.Log ("DISPLAY timer");
	}

	public void HideTimer () {
		timerText.enabled = false;
		Debug.Log ("HIDE timer");
	}

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text>();
		timerText.enabled = false; // Initially timer text shouldn't be visible
		myCoolTimer = 0f;
		trackingTime = false;
	}

	// Update is called once per frame
	void Update () {
		myCoolTimer += Time.deltaTime;
		timerText.text = myCoolTimer.ToString ("f2");
		// If we're tracking time, update myCoolTimer counter
		/*if (trackingTime) {
			myCoolTimer += Time.deltaTime;
			timerText.text = myCoolTimer.ToString ("f2");
		}*/
	}
}
