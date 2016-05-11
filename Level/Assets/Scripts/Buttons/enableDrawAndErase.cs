using UnityEngine;
using System.Collections;

public class enableDrawAndErase : MonoBehaviour {

	// Reference to the GO's DrawPhysicsLine script component
	private DrawPhysicsLine drawingComponent;
	public GameObject[] lines; 	// Array of references to line GOs
	public bool canBuild;	// Flag player's ability to build

	// Enables DrawPhysicsLine and ErasePhysicsLine scripts
	public void EnableBuilding () {
		canBuild = true;

		// Enable drawing ability
		drawingComponent.enabled = true;

		// Enable erasing ability
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = true;
		}
		Debug.Log ("building ENABLED!");
	}

	// Disables DrawPhysicsLine and ErasePhysicsLine scripts
	public void DisableBuilding () {
		canBuild = false;

		// Disable drawing ability
		drawingComponent.enabled = false;

		// Disable erasing ability
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = false;
		}
		Debug.Log ("building DISABLED!");
	}

	// Use this for initialization
	void Start () {
		// Initially give the player the ability to draw and erase
		canBuild = true;
		drawingComponent = gameObject.GetComponent<DrawPhysicsLine> ();
		drawingComponent.enabled = true;
		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = true;
		}
	}

}
