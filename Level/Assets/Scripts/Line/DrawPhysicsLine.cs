using UnityEngine;
using System.Collections;
public class DrawPhysicsLine : MonoBehaviour
{
	private LineRenderer line;	// Reference to LineRenderer
	private Vector3 mousePos;	// Var to store mouse position
	private Vector3 startPos;	// Start position of line
	private Vector3 endPos;		// End position of line
	private int currLines = 0;	// Number of lines
	// State indicating player moused down on a snap point (valid starting point of a line)
	private bool validStart;
	// State indicating player released mouse on a snap point (valid ending point of a line)
	private bool validEnd;
	//references to snap point game objects
	public GameObject spt1;
	public GameObject spt2;
	public GameObject spt3;
	public GameObject spt4;

	void Start () {
		// Initialize snap point GOs
		spt1 = GameObject.Find ("point_1");
		spt2 = GameObject.Find ("point_2");
		spt3 = GameObject.Find ("point_3");
		spt4 = GameObject.Find ("point_4");
		validStart = false;
		validEnd = false;
	}

	void Update () {

		// Create new line on mouse down if location is valid (i.e. on a snap point)
		if (Input.GetMouseButtonDown(0)) {
			validStart = (spt1.GetComponent<snap_point>().validLineStartPoint)
						|| (spt2.GetComponent<snap_point>().validLineStartPoint)
						|| (spt3.GetComponent<snap_point>().validLineStartPoint)
						|| (spt4.GetComponent<snap_point>().validLineStartPoint);
			Debug.Log ("validStart="+validStart);
			// If mouse down on a snap point, start drawing line
			if (validStart) {
				// Check if there's no line renderer created yet
				if (line == null) {
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
		else if (Input.GetMouseButtonUp(0)) {
			validEnd = (spt1.GetComponent<snap_point>().validLineEndPoint)
				|| (spt2.GetComponent<snap_point>().validLineEndPoint)
				|| (spt3.GetComponent<snap_point>().validLineEndPoint)
				|| (spt4.GetComponent<snap_point>().validLineEndPoint);			
			if (line) {
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				mousePos.z = 0;
				// Set the end point of line renderer to current mouse position
				line.SetPosition(1,mousePos);
				endPos = mousePos;

				/* Destroy line GO if line's end point is not a snap point,
				 * otherwise add a collider to the line */
				if (validEnd) {
					Debug.Log ("validEnd on Input.GetMouseButtonUp");
					currLines++;
					//add collider to line so avatar GO can interact w/it
					addColliderToLine();
				} else {
					Destroy(line);
					Debug.Log("line destroyed");
				}
				// Set line as null once valid line is created or invalid line is destroyed
				line = null;
				Debug.Log("line set to null");
			}
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

	// Following method creates line runtime using Line Renderer component
	private void createLine () {
		// Create new empty GO and line renderer component
		line = new GameObject("Line").AddComponent<LineRenderer>();
		// Assign the material to the line
		line.material = new Material(Shader.Find("Diffuse"));
		line.SetVertexCount(2); // Set number of points to the line
		line.SetWidth(0.25f,0.25f); // Set width
		line.SetColors(Color.black, Color.black); //Set color
		// Render line to the world origin and not to the object's position
		line.useWorldSpace = true;
	}

	// Following method adds collider to created line
	private void addColliderToLine () {
		BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D> ();
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
