using UnityEngine;
using System.Collections;

public class customize : MonoBehaviour {

	public string[] clothes;
	private int index;
	private GameObject obj;
	private GameObject previous_obj;


	// Use this for initialization
	void Start () {
		clothes = new string[3];
		clothes [0] = "girl_pink";
		clothes [1] = "girl_purple";
		clothes [2] = "girl_blue";
		reset_clothes ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			if (index == clothes.Length) {
				reset_clothes ();
				index = 0;
			}
			transform.Find(clothes[index]).gameObject.SetActive(true);
			if (index != 0) {
				transform.Find(clothes[index]).gameObject.SetActive(true);
				transform.Find(clothes[index-1]).gameObject.SetActive(false);
			}
			index++;	
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			index--;
			if (index < 0) {
				Debug.Log (index);
				index = clothes.Length - 1;
				transform.Find (clothes [0]).gameObject.SetActive (false);
				transform.Find (clothes [index]).gameObject.SetActive (true);
			} 
			if (index != 0) {
				Debug.Log (index);
				transform.Find (clothes [index - 1]).gameObject.SetActive (true);
				transform.Find (clothes [index]).gameObject.SetActive (false);
			}
			else {
				transform.Find (clothes [0]).gameObject.SetActive (true);
			}
		}
	}
	void reset_clothes() {
		foreach (string clothing in clothes) {
			transform.Find(clothing).gameObject.SetActive (false);
		}
	}
}
