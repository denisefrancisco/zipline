using UnityEngine;
using System.Collections;

public class SelectedPlayer : MonoBehaviour {
	/* DESCRIPTION: This script is used to save the data of the "selected customizable avatar" and is transferred to the gameplay map
	 * MODIFIED: May 14th, 2016
	*/
	private button2_for_customizing left_button;
	private button_for_customizing right_button;
	private button2_for_customizing left_button_girl;
	private button_for_customizing right_button_girl;
	public string chosen_outfit;
	public GameObject avatar;

	void Awake() {
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (avatar);
	}

	// Use this for initialization
	void Start () {
		avatar = GameObject.Find ("Boy");
		if (avatar == null) {
			avatar = GameObject.Find ("girl");
			left_button_girl = avatar.GetComponent<button2_for_customizing> ();
		} else {
			left_button = avatar.GetComponent<button2_for_customizing> ();
		}

	}

	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Boy") == null) {
			chosen_outfit = left_button_girl.chosen_clothing;
		} else {
			chosen_outfit = left_button.chosen_clothing;
		}
		Debug.Log(chosen_outfit);

	}
}