using UnityEngine;
using System.Collections;

public class ApplySnapPoints : MonoBehaviour {

	private float bRadius = 0.625f;	// Original radius for snap point during build mode

	// Set all snap points in the scene to active and reset their radius to its build mode size
	public void applySnapPoint() {
		foreach (Transform child in this.transform) {
			GameObject point = child.gameObject;
			point.SetActive (true);
			point.GetComponent<CircleCollider2D>().radius = bRadius;
		}
	}

}