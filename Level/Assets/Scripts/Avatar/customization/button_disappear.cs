using UnityEngine;
using System.Collections;

public class button_disappear : MonoBehaviour {
	/* DESCRIPTION: Script that hides the button when the player has gone to the end of the list, or is at the beginning of the list.
	 * MODIFIED: May 14th, 2016
	 */
	//get left arrow button
	public GameObject left_button;
	//get right arrow button
	public GameObject right_button;
	private GameObject character;
	private button_for_customizing script;
	private float x1;
	private float y1;
	private float x2;
	private float y2;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Boy") == null) {
			character = GameObject.Find ("girl");
		} else {
			character = GameObject.Find ("Boy");
		}
		script = character.GetComponent<button_for_customizing> ();
		x1 = left_button.transform.position.x;
		y1 = left_button.transform.position.y;
		x2 = right_button.transform.position.x;
		y2 = right_button.transform.position.y;
	}

	public void remove_button(){
		if (script.index == 0) {
			left_button.transform.position = new Vector3 (x1, y1, 10000);
		}
		//if the player is at the end of the outfit list...
		if (script.index == script.clothes.Length-1) {
			right_button.transform.position = new Vector3 (x2, y2, 10000);
			left_button.transform.position = new Vector3 (x1, y1, 10);
		//if the player is neither at the beginning nore at the end of the outfit list...
		} else if (script.index > 0 && script.index < script.clothes.Length) {
			left_button.transform.position = new Vector3 (x1, y1, 10);
			right_button.transform.position = new Vector3 (x2, y2, 10);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
