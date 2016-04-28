using UnityEngine;
using System.Collections;

public class button2_for_customizing : MonoBehaviour {

	//this script is entirely made for looking through the outfits with the left button
	//click_button  is to find the game object left button
	public GameObject click_button;
	//this string is VERY IMPORTANT!! This basically determines which outfit the avatar will wear during the game.
	public string chosen_clothing;
	//character_script is to get the index from the right_button file. The index is to track which outfit is currently being
	//displayed to the player. 
	private GameObject character_script;
	private button_for_customizing button;
	private float x_position;
	private float y_position;

	// Use this for initialization
	void Start () {

		character_script = GameObject.Find ("girl");
		click_button = GameObject.Find ("Button2");

		button = character_script.GetComponent<button_for_customizing> ();
		transform.Find (button.clothes [0]).gameObject.SetActive (true);
		chosen_clothing = "girl_pink";
		button.index = 0;
	}

	public void previous_clothing()
	//only works with the left arrow key
	{
		if (button.index >= 0 | button.index < button.clothes.Length - 1) {
			button.index--;
			Debug.Log (button.index);
			if (button.index > 0) {
				Debug.Log (button.clothes [button.index]);
				transform.Find (button.clothes [button.index + 1]).gameObject.SetActive (false);
				transform.Find (button.clothes [button.index]).gameObject.SetActive (true);
				chosen_clothing = button.clothes [button.index];
			} else {
				transform.Find (button.clothes [0]).gameObject.SetActive (true);
				transform.Find (button.clothes [1]).gameObject.SetActive (false);
				chosen_clothing = "girl_pink";

			}
		}

	}

	// Update is called once per frame
	void Update () {

	}
}



//using UnityEngine;
//using System.Collections;
//
//public class button2_for_customizing : MonoBehaviour {
//	//this file is basically for the left arrow button in the clothing scene.
//	public GameObject click_button;
//	private GameObject character_script;
//	private button_for_customizing button;
//	private float x_position;
//	private float y_position;
//
//	// Use this for initialization
//	void Start () {
//		character_script = GameObject.Find ("girl");
//		click_button = GameObject.Find ("Button2");
//		button= character_script.GetComponent<button_for_customizing> ();
//	}
//
//	public void previous_clothing()
//	//only works with the left arrow key
//	{
//		button.index--;
//		if (button.index != 0 && button.index > 0) {
//			transform.Find(button.clothes[button.index-1]).gameObject.SetActive(true);
//			transform.Find(button.clothes[button.index]).gameObject.SetActive(false);
//		}
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
