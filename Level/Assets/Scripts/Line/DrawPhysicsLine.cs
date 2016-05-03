using UnityEngine;
using System.Collections;

public class DrawPhysicsLine : MonoBehaviour {

	public AudioClip lineTooLongSound;
	private AudioSource audioSource; 

	private GameObject lineGO; // Reference to line game object
	private LineRenderer line;	// Reference to LineRenderer
	private Transform lineTrans; // Transform of line
	private Vector3 mousePos;	// Var to store mouse position
	private Vector3 startPos;	// Start position of line
	private Vector3 endPos;		// End position of line
	private int lineCount = 0;	// Counter for uniquely naming line
	private Color lineColor = new Color (0.427f, 0.431f, 0.443f, 1f);

	// Vars for keeping track of line length
	private float lineWidth = 0.2f;
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

	//sound for drawing a successful zipline
	public AudioClip ziplineDrawSound;
	private AudioSource ziplineSource;

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
		//initialize audio source
		audioSource = gameObject.GetComponent<AudioSource>();
		ziplineSource = gameObject.GetComponent<AudioSource> ();
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
			} else {
				validLength = true;
			}
		}

		// Create new line on mouse down if location is valid (i.e. on a snap point)
		if (Input.GetMouseButtonDown(0)) {
			selectedSnapPoints = GameObject.FindGameObjectsWithTag ("SelectedSnapPoint");
			// If a snap point has been selected as a starting point for a line, flag validStart
			if (selectedSnapPoints.Length == 1) {
				Debug.Log ("moused DOWN on " + selectedSnapPoints[0].name);
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
				line.SetPosition (1, centerSSP); //temporarily set position of second line vertex to centerSSP
				startPos = centerSSP;
			}
		}
		// End a new line on mouse up if location is valid (i.e on a snap point)
		else if (Input.GetMouseButtonUp(0)) {
			foreach (GameObject snappoint in points) {
				if (snappoint.GetComponent<snap_point>().validLineEndPoint) {



					endSnapPoint = snappoint;
					Debug.Log ("moused up on " + endSnapPoint.name);
				}
			}

			if (line) {
				/* Only create a line and add a collider to it if the line's
				 * ending position is valid (i.e. on a snap point) AND the line's
				 * length is valid (i.e. less than maxLineLength);
				 * otherwise line is invalid so destroy it */
				if ((endSnapPoint != null) && validLength) {
					// Get center position of ending snap point (ESP) to set as line's end point
					Vector3 centerESP = endSnapPoint.transform.position;
					centerESP.z = 0;
					line.SetPosition (1, centerESP);
					endPos = centerESP;
					//play the draw button music sound here for successful zipline drawn.
					ziplineSource.PlayOneShot(ziplineDrawSound,1);
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
					audioSource.PlayOneShot (lineTooLongSound, 1.0f);
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

				//Change line color depending on whether line length is valid or invalid
				if (!validLength) { //line is too long
					// if line color isnt' red yet, change it to red
					if (!lineIsRed) {
						line.SetColors(Color.red, Color.red);
						lineIsRed = true;
					}
				} else {	//line is not too long
					//if the line color is already red, change it to black
					if (lineIsRed) {
						line.SetColors(lineColor, lineColor); 
						lineIsRed = false;
					}
				}
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
		line.material = new Material(Shader.Find("Particles/Alpha Blended"));
		//line.material.color = Color.black;
		line.SetVertexCount(2); // Set number of points to the line
		line.SetWidth(lineWidth,lineWidth); // Set width
		line.SetColors(lineColor, lineColor); //Set color
		// Render line to the world origin and not to the object's position
		line.useWorldSpace = true;
	}

	// Adds collider to created line
	private void addColliderToLine () {
		/* Add a collider component directly to the line GO
		(instead of adding it as a child like the comented out code above*/
		BoxCollider2D col = lineGO.AddComponent<BoxCollider2D> ();
		currentLineLength = Vector3.Distance (startPos, endPos); // final length of line

		// Collider size: X is line length, Y is line width, Z set as per requirement
		col.size = new Vector3 (currentLineLength, lineWidth, 1f); 
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

