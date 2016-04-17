﻿using UnityEngine;
using System.Collections;

/*This script should only be enabled if the Erase Button
 * has been clicked to enable the player's ability to
 * erase line objects to which this script is attached
 * (attachment occurs in DrawPhysicsLine script where the
 * line GOs are initially created) */
public class ErasePhysicsLine : MonoBehaviour {

	private GameObject enableErasing; // Reference to GO with erasing scripts attached
	public enableLineErasing lines_list;
	//when line GO is clicked during Erase Mode, delete the line
	void OnMouseDown () {
		//Destroy (gameObject);
		if (enableErasing.GetComponent<enableLineErasing>().canErase) {
			Destroy (gameObject);
			lines_list.lines = GameObject.FindGameObjectsWithTag("Line");
			Debug.Log (lines_list.lines);
		}
	}

	void Start() {
		enableErasing = GameObject.Find ("enableLineErasing"); 
	}

	void Update() {
	}
				
}
