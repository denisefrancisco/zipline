using UnityEngine;
using System.Collections;

public class left_button_customize : MonoBehaviour {

	public GameObject click_button;
	private GameObject character_script;
	private right_button_customize button;
	private float x_position;
	private float y_position;

	// Use this for initialization
	void Start () {
		character_script = GameObject.Find ("Boy");
		click_button = GameObject.Find ("Left Button");
		button= character_script.GetComponent<right_button_customize> ();
		transform.Find (button.clothes [0]).gameObject.SetActive (true);
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
