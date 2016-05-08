using UnityEngine;
using System.Collections;

/*This script should only be enabled if the Erase Button
 * has been clicked to enable the player's ability to
 * erase line objects to which this script is attached
 * (attachment occurs in DrawPhysicsLine script where the
 * line GOs are initially created) */
public class ErasePhysicsLine : MonoBehaviour {

	private enableDrawAndErase enableBuilding; // Reference to erasing script
	public GameObject[] points;	// Array of snap point GOs that serve as vertices of line renderer
	public int clickCounter;	//Counts number of clicks
	public float delay = 1;		// Time between clicks of a double click
	public float firstClickTime;	// Time of first click

	void OnMouseDown () {		
		// If we're in build mode...	
		if (enableBuilding.canBuild) {
			if (clickCounter == 0) {
				// First click
				clickCounter++;		// Increment counter
				firstClickTime = Time.time;		// Save the current time
			} else if (clickCounter == 1) {
				// If second click occurs within the given delay time for a double click...
				if ((Time.time - firstClickTime) <= delay) {
					// Reset snap points attached to line
					foreach (GameObject p in points) {
						p.GetComponent<snap_point> ().usedCounter--;
						p.GetComponent<CircleCollider2D> ().radius = 0.625f;
					}
					Destroy (gameObject);	// Then delete the line
				} else {
					clickCounter = 0; // We've passed the delay time
					Debug.Log("passed delay time! reset click counter");
				}
			}
		} else {
			clickCounter = 0; // Reset clickCounter if not in build mode
		}

	}

	void Start() {
		clickCounter = 0; 	// Initially we have no clicks
		enableBuilding = GameObject.Find("enableBuilding").GetComponent<enableDrawAndErase>(); 
	}
				
}
