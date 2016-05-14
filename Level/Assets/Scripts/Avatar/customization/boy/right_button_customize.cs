using UnityEngine;
using System.Collections;

public class right_button_customize : MonoBehaviour {
	/*DESCRIPTION:This right button customize script is used for the right clothing arrow, to switch outfits towards the end of the
	 * outfit list
	 * MODIFIED: May 14th, 2016
	*/

	public string[] clothes;
	public int index;
	public GameObject lButton;
	private GameObject obj;
	private GameObject previous_obj;
	private Transform first_cloth;
	private left_button_customize clothing;

	// Use this for initialization
	void Start () {
		clothes = new string[3];
		clothes [0] = "blue";
		clothes [1] = "brown";
		clothes [2] = "lightBlue";
		reset_clothes ();
		lButton.transform.position = new Vector3 (lButton.transform.position.x, lButton.transform.position.y, 10000);
		obj = GameObject.Find ("Boy");
		clothing = obj.GetComponent<left_button_customize> ();
		index = 0;
	}
	//next_clothing is to select the outfit towards the end of the clothing list. 
	public void next_clothing(){
		index++;
		Debug.Log (index);
		if (index > 0) {
			//set the next outfit active, and the previous, inactive. 
			transform.Find(clothes[index]).gameObject.SetActive(true);
			transform.Find(clothes[index-1]).gameObject.SetActive(false);
			clothing.chosen_clothing = clothes [index];
		}
	}

	// Update is called once per frame
	void Update () {
	}
	//set all clothing outfits to inactive. 
	void reset_clothes() {
		foreach (string clothing in clothes) {
			transform.Find(clothing).gameObject.SetActive (false);
		}
	}
}
