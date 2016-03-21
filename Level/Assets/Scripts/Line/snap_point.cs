using UnityEngine;
using System.Collections;

public class snap_point : MonoBehaviour {

	private Color startcolor;
	private SpriteRenderer renderer;
	public GameObject zipline;

	void OnMouseDown() { 
		zipline.GetComponent<DrawPhysicsLine>().enabled = true;
	}

	void OnMouseUp() {
//		zipline.GetComponent<DrawPhysicsLine>().enabled = false;
	}

	void OnMouseEnter()
	{
		startcolor = renderer.color;
		renderer.color = Color.black;	
	}
	void OnMouseExit()
	{
		renderer.color = startcolor;

	}

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer>();
		zipline.GetComponent<DrawPhysicsLine>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
