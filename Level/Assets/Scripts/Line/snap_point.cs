using UnityEngine;
using System.Collections;

public class snap_point : MonoBehaviour {

	private Color startcolor;
	private SpriteRenderer renderer;
	public GameObject zipline;
	/* State that checks if user starts drawing a valid line i.e.
	 * if user clicks mouse down on a snap point GO */
	public bool validLineStartPoint;
	/* State that checks if user ends drawing a valid line i.e.
	 * if user clicks mouse up on a snap point GO */
	public bool validLineEndPoint;
	public bool canDraw; //State of player's ability to draw lines

	void OnMouseDown() { 
		/* When a user mouses down on a snap point, that point becomes
		 * a valid starting point for a new zip line segment but an
		 * invalid ending point for that line segment  */
		validLineStartPoint = true;
		validLineEndPoint = false;
		Debug.Log ("valid start pt & invalid end pt OnMouseDown");

		//User can draw lines from this snap point
		canDraw = true;
		zipline.GetComponent<DrawPhysicsLine>().enabled = true;
		Debug.Log ("enableDrawing true, DrawPhysics line enabled");
	}

	void OnMouseUp() {
		/* When a user mouses up on a snap point, that point becomes
		 * a valid ending point for a zip line segment but an
		 * invalid starting point for that line segment
		 * (unless user mouses down on that same snap point) */		
		validLineStartPoint = false;
		validLineEndPoint = true;
		Debug.Log ("valid end pt & invalid start pt OnMouseUp");

		//User can't draw lines from this snap point if mouse is released
		canDraw = false;
		Debug.Log ("enableDrawing false OnMouseUp");
	}

	void OnMouseEnter() {
		startcolor = renderer.color;	//Save initial color of snap point
		//Change snap point color to black when mouse hovers over it
		renderer.color = Color.black;	
	}

	void OnMouseExit() {
		//Change snap point color back to initial color when mouse exits it
		renderer.color = startcolor;

		/* If mouse leaves snap point w/o being held down to draw a line,
		  disable DrawPhysicsLine script */
		if (canDraw == false) {
			zipline.GetComponent<DrawPhysicsLine>().enabled = false;
			Debug.Log ("DrawPhysicsLine disabled OnMouseExit");
		}
	}

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer>();
		//Initially player is unable to draw lines
		zipline.GetComponent<DrawPhysicsLine>().enabled = false;
		validLineStartPoint = false;
		validLineEndPoint = false;
		Debug.Log ("initialized snap point script");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
