using UnityEngine;
using System.Collections;

public class DrawPhysicsLine : MonoBehaviour {

	private GameObject lineGO; // Reference to line game object
	private LineRenderer line;	// Reference to LineRenderer
	private Transform lineTrans; // Transform of line
	private Vector3 mousePos;	// Var to store mouse position
	private Vector3 startPos;	// Start position of line
	private Vector3 endPos;		// End position of line
	private int lineCount = 0;	// Counter for uniquely naming line

	// Vars for keeping track of line length
	private float maxLineLength = 6f;
	private float currentLineLength;

	/* State indicating player moused down on a snap point
	 * (valid starting point of a line) or released mouse on a
	 * snap point (valid ending point of a line) */
	private bool validStart;
	private bool validEnd;
	// Flag indicating line length is valid or not
	private bool validLength;
	// Flag indicating if line is red or not red (specifically black)
	private bool lineIsRed;

	// Array of references to snap point game objects tagged "SnapPoint"
	private GameObject[] points;
	/* Array for storing the GO that the user has selected as either
	the starting or ending snap point of a new line */
	private GameObject[] selectedSnapPoints;
	// References to starting and ending snap point game objects of currently drawn line
	private GameObject startSnapPoint;
	private GameObject endSnapPoint;

	void Start () {
		// Initialize snap point GOs
		points = GameObject.FindGameObjectsWithTag ("SnapPoint");
		// Initialize snap point flags
		validStart = false;
		validEnd = false;
		/* Initialize line length flags to false and vars to true
		 * because we don't initially start with a line GO */
		currentLineLength = 0f;
		lineIsRed = false;
		validLength = false;
	}

	void Update () {

		//if a line exists, calculate its current length
		if (line) {
			//get current mouse position
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			//calculate current line length
			currentLineLength = Vector3.Distance(startPos, mousePos);
			if (currentLineLength > maxLineLength) {
				validLength = false;
				Debug.Log("INVALID line length of " + currentLineLength);
			} else {
				validLength = true;
				Debug.Log("valid line length of " + currentLineLength);

			}
		}

		// Create new line on mouse down if location is valid (i.e. on a snap point)
		if (Input.GetMouseButtonDown(0)) {
			selectedSnapPoints = GameObject.FindGameObjectsWithTag ("SelectedSnapPoint");
			// If a snap point has been selected as a starting point for a line, flag validStart
			if (selectedSnapPoints.Length == 1) {
				validStart = true;
				// Save reference to starting snap point
				startSnapPoint = selectedSnapPoints[0];
				startSnapPoint.GetComponent<snap_point> ().usedCounter++; // increase usedCounter
				startSnapPoint.tag = "SnapPoint"; //reset tag to normal snap point
			}  else {
				validStart = false;	//invalid starting point for line
			}

			// If mouse down on a snap point, start drawing line
			if (validStart) {
				// Check if there's no line renderer created yet, create a new line
				if (line == null) {
					lineCount++;
					createLine ();
				}
				// Get center position of starting snap point (SSP) to set as line's start point
				Vector3 centerSSP = startSnapPoint.transform.position;
				centerSSP.z = 0;
				line.SetPosition (0, centerSSP);
				startPos = centerSSP;
			}
		}
		// End a new line on mouse up if location is valid (i.e on a snap point)
		else if (Input.GetMouseButtonUp(0)) {
			foreach (GameObject snappoint in points) {
				if (snappoint.GetComponent<snap_point>().validLineEndPoint) {
					endSnapPoint = snappoint;
				}
			}

			if (line) {
				/* Destroy line GO if line's end point is not a snap point,
				 * otherwise add a collider to the line */
				if (endSnapPoint != null) {
					// Get center position of ending snap point (ESP) to set as line's end point
					Vector3 centerESP = endSnapPoint.transform.position;
					centerESP.z = 0;
					line.SetPosition (1, centerESP);
					endPos = centerESP;
					//add start and end snap points to points array in ErasePhysicsLine script attached to line GO
					GameObject[] startAndEnd = {startSnapPoint, endSnapPoint};
					lineGO.GetComponent<ErasePhysicsLine> ().points = startAndEnd;
					//flag snap point as used 
					endSnapPoint.GetComponent<snap_point> ().usedCounter++;
					//add collider to line so avatar GO can interact w/it
					addColliderToLine();
				}  else {
					//reset usedCounter to false for start snap point
					startSnapPoint.GetComponent<snap_point> ().usedCounter--;
					Destroy(GameObject.Find("Line"+lineCount));
					lineCount--; //decrement the current number of lines bc we just destroyed a line
				}
				// Set line as null once valid line is created or invalid line is destroyed
				line = null;

				// Reset snap point references and related flags
				validStart = false;
				validEnd = false;
				startSnapPoint = null;
				endSnapPoint = null;

				// Reset line length vars and flags
				currentLineLength = 0f;
				lineIsRed = false;
				validLength = false;
			}
		}
		/* If mouse button is held clicked and line exists, enact "rubber-banding" effect
		 * that is, let the line stretch and rotate as it follows mouse location */
		else if (Input.GetMouseButton(0)) {
			if (line) {
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
		ErasePhysicsLine lineEraseScript = lineGO.AddComponent<ErasePhysicsLine>();
		lineEraseScript.enabled = false;
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
		/* Add a collider component directly to the line GO
		(instead of adding it as a child like the comented out code above*/
		BoxCollider2D col = lineGO.AddComponent<BoxCollider2D> ();
		float lineLength = Vector3.Distance (startPos, endPos); // Length of line

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

