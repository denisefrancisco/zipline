using UnityEngine;
using System.Collections;

public class enableLineErasing : MonoBehaviour {

	// Bool flag representing state of player's ability to erase zip line segments
	public bool canErase; 
	// Array of references to line GOs
	private GameObject[] lines;

	// Enables ErasePhysicsLine script for each line GO in scene
	public void EnableErasing () {
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = true;
			Debug.Log ("erasing enabled!");
		}
	}

	// Disables ErasePhysicsLine script for each line GO in scene
	public void DisableErasing () {
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = false;
			Debug.Log ("erasing disabled!");
		}
	}

	/* Reverses drawing state "canErase" and either enables
	 * or disables the erasing ability accordingly */
	public void SetEraseState(){
		canErase = !canErase;
		// Find all the line GOs in the scene and store in lines array
		lines = GameObject.FindGameObjectsWithTag("Line");
		if (canErase) {
			EnableErasing ();
		}  else {
			DisableErasing ();
		}
	}

	// Use this for initialization
	void Start () {
		//Initially player cannot erase lines
		canErase = false;
		Debug.Log ("initialized canErase="+canErase);
	}

}
