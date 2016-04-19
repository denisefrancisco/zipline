using UnityEngine;
using System.Collections;
public class DrawPhysicsLine : MonoBehaviour
{
	private GameObject lineGO; // Reference to line game object
	private LineRenderer line;	// Reference to LineRenderer
	private Transform lineTrans; // Transform of line
	private Vector3 mousePos;	// Var to store mouse position
	private Vector3 startPos;	// Start position of line
	private Vector3 endPos;		// End position of line
	private int lineCount = 0;	// Counter for uniquely naming line
	private Vector3 offsetEnd;
	private Vector3 offsetStart;

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
		offsetEnd = new Vector3(1,1,0);
		offsetStart = new Vector3 (-0.1f, -0.1f, 0);
	}

	void Update () {

		// Create new line on mouse down if location is valid (i.e. on a snap point)
		if (Input.GetMouseButtonDown(0)) {
			startSnapPoint = GameObject.FindGameObjectsWithTag ("SelectedSnapPoint");

			// If a snap point has been selected as a starting point for a line, flag validStart
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
		// Create new empty GO to serve as our line
		lineGO = new GameObject("Line"+lineCount);
		// Add LineRenderer component to lineGO
		line = lineGO.AddComponent<LineRenderer>();
		/* Attach ErasePhysicsLine script to lineGO and disable the script bc
		 * we don't want to give the player the ability to erase lines yet
		* (only available in Erase Mode activated by EraseButton) */
		ErasePhysicsLine lineScript = lineGO.AddComponent<ErasePhysicsLine>();
		lineScript.enabled = false;
		lineGO.tag = "Line"; // Add the tag "Line" to the line GO

		// Assign the material to the line
		line.material = new Material(Shader.Find("Diffuse"));
		line.SetVertexCount(2); // Set number of points to the line
		line.SetWidth(0.15f,0.15f); // Set width
		line.SetColors(Color.black, Color.black); //Set color
		// Render line to the world origin and not to the object's position
		line.useWorldSpace = true;
	}

	// Adds collider to created line
	private void addColliderToLine () {
		/*BoxCollider2D col = new GameObject("Collider"+lineCount).AddComponent<BoxCollider2D> ();
		col.transform.parent = line.transform; // Collider is added as child object of line */

		/* Add a collider component directly to the line GO
		(instead of adding it as a child like the comented out code above*/
		BoxCollider2D col = lineGO.AddComponent<BoxCollider2D> ();
		float lineLength = Vector3.Distance (startPos+offsetStart, endPos+offsetEnd); // Length of line

		// Size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		col.size = new Vector3 (lineLength, 0.15f, 1f); 

		// Set position of collider object
		Vector3 midPoint = (startPos + endPos)/2;
		col.transform.position = midPoint; 

		// Set offset of collider to (0,0)
		col.offset = Vector2.zero;

		// Calculate the angle between startPos and endPos of line
		float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
		if ((startPos.y<endPos.y && startPos.x>endPos.x) || (endPos.y<startPos.y && endPos.x>startPos.x)) {
			angle*=-1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		col.transform.Rotate (0, 0, angle);
	}
	 
}
