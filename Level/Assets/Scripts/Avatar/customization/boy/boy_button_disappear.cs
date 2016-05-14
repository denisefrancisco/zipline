using UnityEngine;
using System.Collections;

public class boy_button_disappear : MonoBehaviour {
	/*DESCRIPTION: This script is used for hiding the specific arrows when at the end of the "clothes' list"
	 * MODIFIED: May 2nd, 2016
	*/
	public GameObject left_button;
	public GameObject right_button;
	private GameObject character;
	private right_button_customize script;
	private float x1;
	private float y1;
	private float x2;
	private float y2;

	// Use this for initialization
	void Start () {
		character = GameObject.Find ("Boy");
		script = character.GetComponent<right_button_customize>();
		x1 = left_button.transform.position.x;
		y1 = left_button.transform.position.y;
		x2 = right_button.transform.position.x;
		y2 = right_button.transform.position.y;
	}
	/*remove button hides the left arrow when the player is at the start of the clothes list,
	 * hides the right arrows when the player is at the end of the clothes list,
	 * and both arrows shown when in middle of list
	*/
	public void remove_button(){
		if (script.index == 0) {
			left_button.transform.position = new Vector3 (x1, y1, 10000);
		}
		if (script.index == script.clothes.Length-1) {
			right_button.transform.position = new Vector3 (x2, y2, 10000);
			left_button.transform.position = new Vector3 (x1, y1, 10);
		} else if (script.index > 0 && script.index < script.clothes.Length) {
			left_button.transform.position = new Vector3 (x1, y1, 10);
			right_button.transform.position = new Vector3 (x2, y2, 10);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
