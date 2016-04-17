using UnityEngine;
using System.Collections;

public class FloorZone : MonoBehaviour {

	/* Trigger flag for whether avatar has fallen below
	 * lowest snap point into the floor zone
	 * (in which case the avatar has failed to traverse
	 * the zipline course successfully) */
	public bool inFloorZone; 

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("in floor zone");
		inFloorZone = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		inFloorZone = false;
	}

	// Use this for initialization
	void Start () {
		inFloorZone = false;
	}

}
