using UnityEngine;
using System.Collections;
public class DrawPhysicsLine : MonoBehaviour
{
	private LineRenderer line;	// Reference to LineRenderer
	private Transform lineTrans; // Transform of line
	private Vector3 mousePos;	// Var to store mouse position
	private Vector3 startPos;	// Start position of line
	private Vector3 endPos;		// End position of line
	// Var to store new line transform position to bring line forward (in front of furniture)
	private Vector3 tempTransPos;
	private int lineCount = 0;	// Counter for uniquely naming line

	/* State indicating player moused down on a snap point
	 * (valid starting point of a line) or released mouse on a
	 * snap point (valid ending point of a line) */
	private bool validStart;
	private bool validEnd;

	// Array of references to snap point game objects
	public GameObject[] points;
	// Array for storing the GO that becomes the starting snap point of a new line
	public GameObject[] startSnapPoint;


	void Start () {
		// Initialize snap point GOs
		points = GameObject.FindGameObjectsWithTag ("SnapPoint");
		// Initialize boolean flags for valid starting and ending points of a line
		validStart = false;
		validEnd = false;
	}

	void Update () {

		// Create new line on mouse down if location is valid (i.e. on a snap point)
		if (Input.GetMouseButtonDown(0)) {
			startSnapPoint = GameObject.FindGameObjectsWithTag ("SelectedSnapPoint");

			// If a snap point has been selected as a startig point for a line, flag validStart
			if (startSnapPoint.Length == 1) {
				validStart = true;
				//reset tag of selected snap point
				startSnapPoint [0].tag = "SnapPoint";
			} else {
				validStart = false;
			}

			// If mouse down on a snap point, start drawing line
			if (validStart) {
				// Check if there's no line renderer created yet
				if (line == null) {
					lineCount++;
					createLine ();	// Create line

					// Reset line's transform so that line appears in front of furniture
					tempTransPos = lineTrans.position;
					tempTransPos.z = -1f;
					lineTrans.position = tempTransPos;
					Debug.Log ("brought line transform position forward");
				}
				// Get mouse position
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				// Set z coordinate to 0 (only consider x-y axes in 2D)
				mousePos.z = 0;
				// Set the start point
				line.SetPosition (0, mousePos);
				startPos = mousePos;
			}
		}
		// End a new line on mouse up if location is valid (i.e on a snap point)
		else if (Input.GetMouseButtonUp(0)) {
			// Check if mouse up location is valid for currently drawn line
			foreach (GameObject snappoint in points) {
				validEnd = validEnd || (snappoint.GetComponent<snap_point>().validLineEndPoint);
			}

			if (line) {
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePos.z = 0;
				// Set the end point of line renderer to current mouse position
				line.SetPosition(1,mousePos);
				endPos = mousePos;

				/* Destroy line GO if line's end point is not a snap point,
				 * otherwise add a collider to the line */
				if (validEnd) {
					//add collider to line so avatar GO can interact w/it
					addColliderToLine();
				} else {
					Destroy(GameObject.Find("Line"+lineCount));
					lineCount--; //decrement the current number of lines bc we just destroyed a line
				}
				// Set line as null once valid line is created or invalid line is destroyed
				line = null;
			}

			// Reset flags
			validStart = false;
			validEnd = false;
		}
		/* If mouse button is held clicked and line exists, enact "rubber-banding" effect
		 * that is, let the line stretch and rotate as it follows mouse location */
		else if (Input.GetMouseButton(0)) {
			if (line) {
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePos.z = 0;
				/* Set the end point of line renderer as current position
				 * but don't set line as null as the user hasn't yet moused up */
				line.SetPosition(1,mousePos);
			}
		}
	}

	// Creates line using Line Renderer component
	private void createLine () {
		// Create new empty GO and line renderer component
		line = new GameObject("Line"+lineCount).AddComponent<LineRenderer>();
		lineTrans = line.GetComponent<Transform> ();	//Initialize line's transform
		// Assign the material to the line
		line.material = new Material(Shader.Find("Diffuse"));
		line.SetVertexCount(2); // Set number of points to the line
		line.SetWidth(0.25f,0.25f); // Set width
		line.SetColors(Color.black, Color.black); //Set color
		// Render line to the world origin and not to the object's position
		line.useWorldSpace = true;
	}

	// Adds collider to created line
	private void addColliderToLine () {
		BoxCollider2D col = new GameObject("Collider"+lineCount).AddComponent<BoxCollider2D> ();
		col.transform.parent = line.transform; // Collider is added as child object of line

		float lineLength = Vector3.Distance (startPos, endPos); // Length of line

		// Size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		col.size = new Vector3 (lineLength, 0.25f,1f); 

		// Set position of collider object
		Vector3 midPoint = (startPos + endPos)/2;
		col.transform.position = midPoint; 

		// Calculate the angle between startPos and endPos of line
		float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
		if ((startPos.y<endPos.y && startPos.x>endPos.x) || (endPos.y<startPos.y && endPos.x>startPos.x)) {
			angle*=-1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		col.transform.Rotate (0, 0, angle);
	}
	 
}
