using UnityEngine;
using System.Collections;

public class changeSnapPointsOnPlay : MonoBehaviour {

	private GameObject[] points;

	public void changeSnapPoints () {
		foreach (GameObject p in points) {
			int count = p.GetComponent<snap_point> ().usedCounter;
			CircleCollider2D col = p.GetComponent<CircleCollider2D> ();
			//snap point p has been used as part of an existing line
			if (count > 0) {
				col.radius = 0.38f;	//make collider radius same size as line width
			} else { //snap point p hasn't been used
				p.SetActive(false); //disable collider so avatar doesn't run into it
			}
		}
	}

	// Use this for initialization
	void Start () {
		points = GameObject.FindGameObjectsWithTag ("SnapPoint");
	}
	
}
