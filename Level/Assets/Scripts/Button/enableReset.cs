using UnityEngine;
using System.Collections;

public class enableReset : MonoBehaviour {

	// References to arrays of lines and snap points
	private GameObject[] lines;
	private GameObject[] snapPoints;
	private snap_point snapPointScript;

	/* Resets the layout of the level (reset snap points
	 * and delete all previously made lines)*/
	public void resetLayout () {
		lines = GameObject.FindGameObjectsWithTag("Line"); //initialize lines array
		// Destroy line and material (destroying material prevents memory leak)
		foreach (GameObject l in lines) {
			Destroy(l);
			Destroy(l.GetComponent<Renderer>().material);
		}

		// Reset all snap points
		foreach (GameObject p in snapPoints) {
			snapPointScript = p.GetComponent<snap_point>(); //grab snap point script
			p.tag = "SnapPoint";	//reset tag
			p.GetComponent<CircleCollider2D>().radius = 0.625f; //reset snap point radius
			snapPointScript.usedCounter = 0;	//reset used snap point counter
			// reset boolean flags
			snapPointScript.validLineStartPoint = false;	
			snapPointScript.validLineEndPoint = false;
		}
	}

	// Use this for initialization
	void Start () {
		snapPoints = GameObject.FindGameObjectsWithTag("SnapPoint");
	}

}
