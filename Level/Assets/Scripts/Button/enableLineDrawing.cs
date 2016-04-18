using UnityEngine;
using System.Collections;

public class enableLineDrawing : MonoBehaviour {

	// Bool flag representing state of player's ability to draw zip line segments
	public bool canDraw; 
	// Disable Erase when in play mode
	public enableLineErasing disableErase;
	public enableLineErasing line_erase;
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


	/*This Function is for the Play button, to set the active object to false when watching zipline*/
	public void disableDrawAndErase() {
		canDraw = false;
		disableErase.canErase = false;
		Debug.Log ("disableDrawandErase");
		Debug.Log (disableErase.canErase);
	}
	//This Function is for the enabling the draw and erase functions through reset button
	public void enableDrawAndErase() {
		SetDrawingState ();
	}


	/* Reverses drawing state "canDraw" and either enables
	 * or disables the drawing ability accordingly */
	public void SetDrawingState(){
		canDraw = !canDraw;
		if (canDraw) {
			EnableDrawing ();
		} else {
			DisableDrawing ();
		}
	}

	// Use this for initialization
	void Start () {
		// Initially player is unable to draw zip line segments
		canDraw = false;
		drawingComponent = gameObject.GetComponent<DrawPhysicsLine> ();
	}

}
