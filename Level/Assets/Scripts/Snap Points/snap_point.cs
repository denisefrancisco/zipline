using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class snap_point : MonoBehaviour {

	private Color startcolor;
	private SpriteRenderer renderer;
	/* State that checks if user starts drawing a valid line i.e.
	 * if user clicks mouse down on a snap point GO */
	public bool validLineStartPoint;
	/* State that checks if user ends drawing a valid line i.e.
	 * if user clicks mouse up on a snap point GO */
	public bool validLineEndPoint;
	/* Count indicating how many existing lines this snap point is
	 * currently attached to */
	public int usedCounter;
	private float initRadius = 0.625f;	// radius of 2D circle collider

	void OnMouseDown () { 
		/* When a user mouses down on a snap point, that point becomes
		 * a valid starting point for a new zip line segment */
		gameObject.tag = "SelectedSnapPoint";
		validLineStartPoint = true;
	}

	void OnMouseEnter () {
		startcolor = renderer.color;	//Save initial color of snap point
		//Change snap point color to black when mouse hovers over it
		renderer.color = Color.black;

		/* When a user mouses over a snap point, that point becomes a
		 * valid ending point for the latest drawn line segment */
		validLineEndPoint = true;
	}

	void OnMouseExit () {
		//Change snap point color back to initial color when mouse exits it
		renderer.color = startcolor;

		/* When a user mouse exits a snap point, that point becomes an
		 * invalid ending point for the latest drawn line segment */
		validLineEndPoint = false;
	}

	/* When a user mouses up, use raycasting to see if the current mouse
	 * position is on another snap point, which will be a valid line ending point*/
	/*void OnMouseUp () { 
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
		if (hit != null) {
			GameObject objectHit = hit.transform.gameObject;
			// If player has touched up on a snap point
			if (objectHit.tag == "SnapPoint") {
				// This snap point GO becomes a valid ending point for a new line
				objectHit.GetComponent<snap_point>().validLineEndPoint = true;
			}
		}
	}*/

	// Use this for initialization
	void Start () {
		// Initialize reference to snap point sprite renderer
		renderer = gameObject.GetComponent<SpriteRenderer>();
		// Set initial radius of snap point GO
		gameObject.GetComponent<CircleCollider2D> ().radius = initRadius;
		//snap point hasn't been used in line creation yet, so all flags set to false
		validLineStartPoint = false;
		validLineEndPoint = false;
		usedCounter = 0;
	}


}

