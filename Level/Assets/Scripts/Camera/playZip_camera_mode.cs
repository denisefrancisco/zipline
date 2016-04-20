﻿using UnityEngine;
using System.Collections;

public class playZip_camera_mode : MonoBehaviour {

	public GameObject player;
	public Camera allcameraData;
	public GameObject lose_panel;
	public GameObject success_panel;
	public GameObject timer;
	private Vector3 offset = new Vector3 (0,0,-157);

	// Use this for initialization
	void Start () {
		lose_panel.SetActive (false);
	
	}

	//in order to reset the lose modal, whenever the restart button is pressed, set active =false
	public void resetModal(){
		lose_panel.SetActive (false);
		success_panel.SetActive (false);
		timer.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		Transform characterTransform = player.transform;
		Vector3 characterPosition = characterTransform.position;
		allcameraData.transform.position = characterPosition + offset;
		if (player.transform.position.x >= -3.2f) {
			timer.SetActive (true);
		}
	}
}
//using UnityEngine;
//using System.Collections;
//
//public class playZip_camera_mode : MonoBehaviour {
//
//	public Transform player;
//	public Vector3 offset = new Vector3 (0,0,-1);
//	public Camera playCamera;
//
//	void Update () 
//	{
//		transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
//		playCamera.transform.position = transform.position;
//	}
//
//}
