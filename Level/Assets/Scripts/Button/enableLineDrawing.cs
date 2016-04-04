using UnityEngine;
using System.Collections;

public class enableLineDrawing : MonoBehaviour {

	// Bool flag representing state of player's ability to draw zip line segments
	private bool canDraw; 

	// Enables DrawPhysicsLine script
	public void EnableDrawing () {
		gameObject.GetComponent<DrawPhysicsLine> ().enabled = true;
		Debug.Log ("drawing enabled!");
	}

	// Disables DrawPhysicsLine script
	public void DisableDrawing () {
		gameObject.GetComponent<DrawPhysicsLine> ().enabled = false;
		Debug.Log ("drawing disabled!");
	}

	/* Reverses drawing state "canDraw" and either enables
	 * or disables the drawing ability accordingly */
	public void SetDrawingState(){
		canDraw = !canDraw;
		Debug.Log("on mouse click canDraw=" + canDraw);
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
	}

}
