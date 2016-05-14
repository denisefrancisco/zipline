using UnityEngine;
using System.Collections;

public class button2_for_customizing : MonoBehaviour {

	//this script is entirely made for looking through the outfits with the left button
	//click_button  is to find the game object left button
//	public GameObject click_button;
	//this string is VERY IMPORTANT!! This basically determines which outfit the avatar will wear during the game.
	public string chosen_clothing;
	//character_script is to get the index from the right_button file. The index is to track which outfit is currently being
	//displayed to the player. 
	private GameObject character_script;
	private button_for_customizing button;
	private float x_position;
	private float y_position;

	void Awake(){
		if (GameObject.Find ("Boy") == null) {
			character_script = GameObject.Find ("girl");
			chosen_clothing = "girl_pink";
		} else {
			Debug.Log ("WE FOUND A BOY!!");
			character_script = GameObject.Find ("Boy");
			chosen_clothing = "blue";
		}
	}

	// Use this for initialization
	void Start () {
		button = character_script.GetComponent<button_for_customizing> ();
		transform.Find (button.clothes [0]).gameObject.SetActive (true);
		button.index = 0;
	}

	public void previous_clothing()
	//only works with the left arrow key
	{
		if (button.index >= 0 | button.index < button.clothes.Length - 1) {
			button.index--;
			if (button.index > 0) {
				transform.Find (button.clothes [button.index + 1]).gameObject.SetActive (false);
				transform.Find (button.clothes [button.index]).gameObject.SetActive (true);
				chosen_clothing = button.clothes [button.index];
			} else {
				transform.Find (button.clothes [0]).gameObject.SetActive (true);
				transform.Find (button.clothes [1]).gameObject.SetActive (false);
				if (GameObject.Find("Boy") == null) {
					chosen_clothing = "girl_pink";
				} else {
					chosen_clothing = "blue";
				}

			}
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
