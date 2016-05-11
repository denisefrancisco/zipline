using UnityEngine;
using System.Collections;

public class start_play_camera : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Avatar");

	}

	public void setAvatarActive() {
		transform.Find (player.name).gameObject.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
