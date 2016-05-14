using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class hoverActivation : MonoBehaviour {

	private GameObject girl;
	private GameObject boy;

	// Use this for initialization
	void Start () {
		girl = GameObject.Find("female");
		boy = GameObject.Find("male");
		if (SystemInfo.deviceModel.Contains ("iPad")) {
			if (SceneManager.GetActiveScene ().name == "zipline_choose_gender") {
				
					girl.GetComponent<Animator> ().enabled = false;
					boy.GetComponent<Animator> ().enabled = false;
				
			} else {
				foreach (Transform x in gameObject.transform) {
					if (x.name != "BackButton") {
						x.GetComponent<Animator> ().enabled = false;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
