using UnityEngine;
using System.Collections;

public class changeSnapPointsOnPlay : MonoBehaviour {

	private GameObject[] points;	// List of all snap points in the scene
	private float newRadius = 0.22f;	// Smaller radius for snap point during play mode

	// For each snap point, change its radius if attached to a line, otherwise deactivate it
	public void changeSnapPoints () {
		foreach (GameObject p in points) {
			int count = p.GetComponent<snap_point> ().usedCounter;
			CircleCollider2D col = p.GetComponent<CircleCollider2D> ();
			// If snap point has been used as part of an existing line...
			if (count > 0) {
				col.radius = newRadius;	// Make collider radius same size as line width
			} else { 
				// If snap point hasn't been used...
				p.SetActive(false); // Disable its circle collider so avatar doesn't run into it
			}
		}
	}

	// Use this for initialization
	void Start () {
		points = GameObject.FindGameObjectsWithTag ("SnapPoint");	// Initialize snap point list
	}
	
}
