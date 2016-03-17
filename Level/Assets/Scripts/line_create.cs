using UnityEngine;
using System.Collections;

public class line_create : MonoBehaviour {

	private LineRenderer lineRenderer;
	private float counter;
	private float dist; //distance
	private bool line_flag = false;

	public Transform origin;
	public Transform destination;
	public Vector3 mouse_pos;
	public Vector3 a;
	public Vector3 b;

	/*Things That Need to be Done by TODAY. 3/14/16 --
	 * Adding a box collider with the line renderer (DO THIS NOW) (DONE)
	 * adding another circle game object to connect the line to. (50%)
	 * Making sure that the click is in a game object, doesn't respond to anything else (100%)
	 * Save lines that were made previously by the user. (0%)
	 */

	public float lineDrawSpeed = 6f;

	// Use this for initialization
	void Start () {
		//we want to cache/get the lineRenderer
		lineRenderer = GetComponent<LineRenderer>();
		//line below, when referring to 0, is referring to Element 0 in lineRenderer
		//starting point of this line will at origin's position (see gameobjects in UnitY)
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetWidth (0.45f, 0.45f);

		//distance between origin point and destination gameObject
		dist = Vector3.Distance(origin.position, destination.position);
	}
	
	// Update is called once per frame
	void Update () {
		// assigning origin and destination
		Vector3 a = origin.position;
		Vector3 b = destination.position;
		//getting coordinates of mouse click
		if (Input.GetMouseButtonDown (0) == true) {
			line_flag = true;
			mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (mouse_pos);
		}
		if (line_flag == true) {
			Debug.Log ("We made it!");
			makeLine(a,b);
//			makeLine1 ();
		}


	}

	void makeLine(Vector3 pointA, Vector3 pointB) {
		if (counter < dist) {
			counter += .1f / lineDrawSpeed;
			//Linear interpolation of two numbers based off of some type of time which is counter
			float x = Mathf.Lerp (0, dist, counter);

//			Vector3 pointA = origin.position;
//			Vector3 pointB = destination.position;
//
			//Get the unit vector in the desired destination, multiply by the desired length and
			//add the starting point
			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;

			lineRenderer.SetPosition (1, pointAlongLine);
		}
	}
}
