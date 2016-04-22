using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enableLineDrawing : MonoBehaviour {

	// Reference to the GO's DrawPhysicsLine script component
	private DrawPhysicsLine drawingComponent;
	public bool canDraw;	// Flag player's ability to draw

	// Enables DrawPhysicsLine script
	public void EnableDrawing () {
		canDraw = true;
		drawingComponent.enabled = true;
		Debug.Log ("drawing enabled!");
	}

	// Disables DrawPhysicsLine script
	public void DisableDrawing () {
		canDraw = false;
		drawingComponent.enabled = false;
		Debug.Log ("drawing disabled!");
	}

	// Use this for initialization
	void Start () {
		drawingComponent = gameObject.GetComponent<DrawPhysicsLine> ();
		canDraw = false;
	}

}
