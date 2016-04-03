﻿using UnityEngine;
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

	void OnMouseDown () { 
		/* When a user mouses down on a snap point, that point becomes
		 * a valid starting point for a new zip line segment */
		gameObject.tag = "SelectedSnapPoint";
		validLineStartPoint = true;
	}

	void OnMouseUp () {	
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

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer>();
		zipline.GetComponent<DrawPhysicsLine>().enabled = true;	//MOVE THIS when the build mode script works
		validLineStartPoint = false;
		validLineEndPoint = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
