using UnityEngine;
using System.Collections;

public class enableLineDrawing : MonoBehaviour {

	// Reference to the GO's DrawPhysicsLine script component
	private DrawPhysicsLine drawingComponent;


	// Enables DrawPhysicsLine script
	public void EnableDrawing () {
		drawingComponent.enabled = true;
		Debug.Log ("drawing enabled!");
	}

	// Disables DrawPhysicsLine script
	public void DisableDrawing () {
		drawingComponent.enabled = false;
		Debug.Log ("drawing disabled!");
	}

	// Use this for initialization
	void Start () {
		drawingComponent = gameObject.GetComponent<DrawPhysicsLine> ();
	}

}
