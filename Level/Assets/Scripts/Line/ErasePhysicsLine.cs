using UnityEngine;
using System.Collections;

/*This script should only be enabled if the Erase Button
 * has been clicked to enable the player's ability to
 * erase line objects to which this script is attached
 * (attachment occurs in DrawPhysicsLine script where the
 * line GOs are initially created) */
public class ErasePhysicsLine : MonoBehaviour {

	private GameObject enableErasing; // Reference to GO with erasing scripts attached
	public GameObject[] points;	// Array of snap point GOs that serve as vertices of line renderer

	void OnMouseDown () {
		if (enableErasing.GetComponent<enableLineErasing> ().canErase) {
			if (points.Length > 0) {
				foreach (GameObject p in points) {
					p.GetComponent<snap_point> ().usedCounter--;
				}
			}
			//when line GO is clicked during Erase Mode, delete the line
			Destroy (gameObject);
		}
	}

	void Start() {
		enableErasing = GameObject.Find ("enableLineErasing"); 
	}
				
}
