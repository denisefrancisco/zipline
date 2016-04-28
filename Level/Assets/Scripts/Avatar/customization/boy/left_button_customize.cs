using UnityEngine;
using System.Collections;

public class left_button_customize : MonoBehaviour {

	//this script is entirely made for looking through the outfits with the left button
	//click_button  is to find the game object left button
	public GameObject click_button;
	//this string is VERY IMPORTANT!! This basically determines which outfit the avatar will wear during the game.
	public string chosen_clothing;
	//character_script is to get the index from the right_button file. The index is to track which outfit is currently being
	//displayed to the player. 
	private GameObject character_script;
	private right_button_customize button;
	private float x_position;
	private float y_position;

	// Use this for initialization
	void Start () {
		
		character_script = GameObject.Find ("Boy");
		click_button = GameObject.Find ("Left Button");

		button = character_script.GetComponent<right_button_customize> ();
		transform.Find (button.clothes [0]).gameObject.SetActive (true);
		chosen_clothing = "blue";
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
				chosen_clothing = "blue";

			}
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
