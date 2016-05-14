using UnityEngine;
using System.Collections;

public class button_for_customizing : MonoBehaviour {
	/* DESCRIPTION: Script that hides the button when the player has gone to the end of the list, or is at the beginning of the list.
	 * MODIFIED: May 14th, 2016
	 */
	public string[] clothes;
	public int index;
	public GameObject lButton;
	private GameObject avatar;
	private GameObject previous_obj;
	private Transform first_cloth;
	private button2_for_customizing clothing;

	void Awake() {
		clothes = new string[3];
		if (GameObject.Find ("Boy") == null) {
			clothes [0] = "girl_pink";
			clothes [1] = "girl_white";
			clothes [2] = "girl_blue";
			reset_clothes ();
			avatar = GameObject.Find ("girl");
			clothing = avatar.GetComponent<button2_for_customizing> ();
		} else {
			clothes [0] = "blue";
			clothes [1] = "brown";
			clothes [2] = "lightBlue";
			reset_clothes ();
			avatar = GameObject.Find ("Boy");
			clothing = avatar.GetComponent<button2_for_customizing> ();
		}
		lButton.transform.position = new Vector3 (lButton.transform.position.x, lButton.transform.position.y, 10000);
		index = 0;
	}

	// Use this for initialization
	void Start () {

	}
	//next_clothing is to select the outfit towards the end of the clothing list. 
	public void next_clothing(){
		index++;
		if (index > 0) {
			Debug.Log ("AYEEE");
			transform.Find(clothes[index]).gameObject.SetActive(true);
			transform.Find(clothes[index-1]).gameObject.SetActive(false);
			clothing.chosen_clothing = clothes [index];
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void reset_clothes() {
		foreach (string clothing in clothes) {
			transform.Find(clothing).gameObject.SetActive (false);
		}
	}
}
