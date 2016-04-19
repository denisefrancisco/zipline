﻿using UnityEngine;
using System.Collections;

public class slide_camera : MonoBehaviour {

	public Transform farLeft;
	public Transform farRight;
	public Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera.transform.position = new Vector3(-3.8f,mainCamera.transform.position.y,mainCamera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		if (Input.mousePosition.x >= Screen.width - 20) {
			if (transform.position.x <= farRight.position.x) {
				newPosition.x += 0.05f;
				transform.position = newPosition;
			}
		}
		if (Input.mousePosition.x <= 0 + 20) {
			if (transform.position.x >= farLeft.position.x) {
				newPosition.x -= 0.05f;
				transform.position = newPosition;
			}
		}
	}
		
	}