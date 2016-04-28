using UnityEngine;
using System.Collections;

public class pan_level : MonoBehaviour {

	//panning the level, we need to use the upper and lower boundaries of the main camera.
	public Transform upperBoundary;
	public Transform lowerBoundary;
	private Vector3 current_pos;
	private pan_level script;
	private Vector3 initial_pos;
	private bool isDown = false;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
//		GetComponent<Camera>().transform.position = lowerBoundary.position - new Vector3(0,0,0.2f);
		initial_pos = gameObject.transform.position;
		script = gameObject.GetComponent<pan_level>();
		canvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Camera> ().transform.position.y - 0.2f >= lowerBoundary.position.y && isDown == false) {
			current_pos = GetComponent<Camera> ().transform.position;
			current_pos.y -= 0.05f;
			GetComponent<Camera> ().transform.position = current_pos;
		} else if (GetComponent<Camera> ().transform.position.y + 0.2f <= upperBoundary.position.y) {
			isDown = true;
			current_pos = GetComponent<Camera> ().transform.position;
			current_pos.y += 0.05f;
			GetComponent<Camera> ().transform.position = current_pos;
		} else {
			gameObject.transform.position = initial_pos;
			canvas.SetActive (true);
			script.enabled = false;
		}
	
	}
}
