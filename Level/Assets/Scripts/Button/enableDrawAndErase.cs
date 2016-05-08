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

		drawingComponent.enabled = true;

		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = true;
		}
		Debug.Log ("building enabled!");
	}

	// Disables DrawPhysicsLine and ErasePhysicsLine scripts
	public void DisableBuilding () {
		canBuild = false;

		drawingComponent.enabled = false;

		lines = GameObject.FindGameObjectsWithTag ("Line");
		foreach (GameObject line in lines) {
			line.GetComponent<ErasePhysicsLine> ().enabled = false;
		}
		Debug.Log ("building disabled!");
	}

	// Use this for initialization
	void Start () {
		drawingComponent = gameObject.GetComponent<DrawPhysicsLine> ();
		// Initially give the player the ability to draw
		canBuild = true;
		drawingComponent.enabled = true;
	}

}
