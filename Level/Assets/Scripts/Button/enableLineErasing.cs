using UnityEngine;
using System.Collections;

public class enableLineErasing : MonoBehaviour {

	// Array of references to line GOs
	public GameObject[] lines;

	// Enables ErasePhysicsLine script for each line GO in scene
	public void EnableErasing () {
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = true;
			Debug.Log ("erasing enabled!");
		}

	}

	// Disables ErasePhysicsLine script for each line GO in scene
	public void DisableErasing () {
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = false;
		}
		Debug.Log ("erasing disabled!");
	}

}
