using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pan_level : MonoBehaviour {

	//panning the level, we need to use the upper and lower boundaries of the main camera.
	public Transform upperBoundary;
	public Transform lowerBoundary;
	public GameObject playArrow;
	public GameObject canvas;

	private Vector3 current_pos;
	private pan_level script;
	private Vector3 initial_pos;

	// Use this for initialization
	void Start () {
		initial_pos = gameObject.transform.position;
		Camera.main.transform.position = new Vector3(lowerBoundary.position.x,lowerBoundary.position.y,-156.34f);
		script = gameObject.GetComponent<pan_level>();
		removeCanvas ();

	}
	//set all canvas buttons except the "Play Level Button", inactive.
	void removeCanvas(){
		foreach (Transform button in canvas.transform) {
			if (button.name != "Play Level Button") {
				button.gameObject.SetActive (false);
			}
		}
	}

	//set all canvas buttons except the "Play Level Button", inactive.
	void applyCanvas(){
		foreach (Transform button in canvas.transform) {
			if (button.name != "Play Level Button" && button.name != "OptionsModal") {
				button.gameObject.SetActive (true);
			} else {
				button.gameObject.SetActive (false);
			}
		}
		if (SceneManager.GetActiveScene ().name == "LabLevel4") {
			playArrow.SetActive (true);
		}
	}
	//this wait feature is to hold the camera for 2 seconds at the top of the map, and then pan down
	IEnumerator wait() {
		yield return new WaitForSeconds (1);
		panUp ();
	}

	public void DestroyPanLevel(){
		applyCanvas ();
		Destroy (script);
	}
	//reinitialize isDown to be true to allow the else if condition to pass, so that it can pan Up continuously until the top of the screen
	void panUp() {
		current_pos = GetComponent<Camera> ().transform.position;
		current_pos.y += 0.05f;
		GetComponent<Camera> ().transform.position = current_pos;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Camera> ().transform.position.y >= upperBoundary.position.y) {
			StopAllCoroutines();
			gameObject.transform.position = initial_pos;
			applyCanvas ();
			script.enabled = false;
		} 
		else {
			StartCoroutine (wait());
		}
	
	}
}
