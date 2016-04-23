using UnityEngine;
using System.Collections;

public class button_for_customizing : MonoBehaviour {

	public string[] clothes;
	//index represents the current outfit prefab you are currently on in the list
	public int index;
	public GameObject lButton;
	private GameObject obj;
	private GameObject previous_obj;
	private Transform first_cloth;


	// Use this for initialization
	void Start () {
		//clothes is a list of all outfit prefabs that we need for the girl.
		clothes = new string[3];
		clothes [0] = "girl_pink";
		clothes [1] = "girl_purple";
		clothes [2] = "girl_blue";
		//reset clothes is to basically set all prefab outfits to inactive so that they can try again
		reset_clothes ();
		//this is to make sure that the transform of the button is way in the front of the screen
		lButton.transform.position = new Vector3 (lButton.transform.position.x, lButton.transform.position.y, 10000);
		index = 0;
	}
	//next_clothing is to shift through outfit prefabs
	public void next_clothing(){
		
		if (index == 0) {
			transform.Find(clothes[index]).gameObject.SetActive(true);
		}
		else if (index != 0) {
			transform.Find(clothes[index]).gameObject.SetActive(true);
			transform.Find(clothes[index-1]).gameObject.SetActive(false);
		}
		index++;


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
