using UnityEngine;
using System.Collections;

public class right_button_customize : MonoBehaviour {

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
		//		first_cloth = transform.Find (clothes [0]);
		//		first_cloth.gameObject.SetActive(true);
		lButton.transform.position = new Vector3 (lButton.transform.position.x, lButton.transform.position.y, 10000);
		index = 0;
	}

	public void next_clothing(){
		index++;
		Debug.Log (index);
		if (index > 0) {
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
