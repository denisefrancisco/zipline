using UnityEngine;
using System.Collections;

public class button2_for_customizing : MonoBehaviour {
	//this file is basically for the left arrow button in the clothing scene.
	public GameObject click_button;
	private GameObject character_script;
	private button_for_customizing button;
	private float x_position;
	private float y_position;

	// Use this for initialization
	void Start () {
		character_script = GameObject.Find ("girl");
		click_button = GameObject.Find ("Button2");
		button= character_script.GetComponent<button_for_customizing> ();
	}

	public void previous_clothing()
	//only works with the left arrow key
	{
		button.index--;
		if (button.index != 0 && button.index > 0) {
			transform.Find(button.clothes[button.index-1]).gameObject.SetActive(true);
			transform.Find(button.clothes[button.index]).gameObject.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
