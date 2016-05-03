using UnityEngine;
using System.Collections;

public class deactivateLevelMusic : MonoBehaviour {

	public GameObject success_modal;
	public GameObject failure_modal;
	private GameObject avatar;

	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
	}
	
	// Update is called once per frame
	void Update () {
//		if (success_modal.activeSelf == true || failure_modal.activeSelf == true) {
		if (avatar.activeSelf == false){
			gameObject.GetComponent<AudioSource> ().enabled = false;
		} else {
			gameObject.GetComponent<AudioSource> ().enabled = true;
		}
	
	}
}
