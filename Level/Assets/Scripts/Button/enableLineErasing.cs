using UnityEngine;
using System.Collections;

public class enableLineErasing : MonoBehaviour {

	// Array of references to line GOs
	public GameObject[] lines;
	public bool canErase;	// Flag player's ability to erase


	// Enables ErasePhysicsLine script for each line GO in scene
	public void EnableErasing () {
		canErase = true;
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = true;
			Debug.Log ("erasing enabled!");
		}

	}

	// Disables ErasePhysicsLine script for each line GO in scene
	public void DisableErasing () {
		canErase = false;
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = false;
		}
		Debug.Log ("erasing disabled!");
	}

}
