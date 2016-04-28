using UnityEngine;
using System.Collections;

public class button_for_customizing : MonoBehaviour {

	public string[] clothes;
	public int index;
	public GameObject lButton;
	private GameObject obj;
	private GameObject previous_obj;
	private Transform first_cloth;
	private button2_for_customizing clothing;

	// Use this for initialization
	void Start () {
		clothes = new string[3];
		clothes [0] = "girl_pink";
		clothes [1] = "girl_white";
		clothes [2] = "girl_blue";
		reset_clothes ();
		//		first_cloth = transform.Find (clothes [0]);
		//		first_cloth.gameObject.SetActive(true);
		lButton.transform.position = new Vector3 (lButton.transform.position.x, lButton.transform.position.y, 10000);
		obj = GameObject.Find ("girl");
		clothing = obj.GetComponent<button2_for_customizing> ();
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
