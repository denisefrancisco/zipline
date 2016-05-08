using UnityEngine;
using System.Collections;

public class doubleTapAnimate : MonoBehaviour {
	/* DESCRIPTION: This script is used for the purposes of having double tap animation used as a "tutorial"
	 * during Level 2 (the erasing line action)
	 * MODIFIED: May 8th, 2016
	*/
	#if UNITY_STANDALONE_OSX
	//The buttonClick refers to the sprite that has the blue button left click
	public Transform buttonClick;
	//The drawLine gameObject refers to the line renderer that is used as a demo-zipline
	public GameObject drawLine;
	//The tutorialText refers to the text written above drawLine
	public GameObject tutorialText;

	void Awake(){
		StartCoroutine("SetGuard");
	}

	// Use this for initialization
	void Start () {
		drawLine = GameObject.Find ("Quad");
	}

	//SetGuard is a special function which is used to loop the tutorial, animated gestures..
	IEnumerator SetGuard() {
		while (true)
		{
			yield return new WaitForSeconds (1);
			drawLine.SetActive (true);
			yield return new WaitForSeconds (1);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
			yield return new WaitForSeconds (0.2f);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,5);
			yield return new WaitForSeconds (0.2f);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
			yield return new WaitForSeconds (0.2f);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,5);
			drawLine.SetActive (false);
		}
	}
	// Update is called once per frame
	void Update () {
		//Once the player starts experiment with the UI, remove tutorial GameObjects
		if (Input.GetMouseButton (0) == true) {
			gameObject.SetActive (false);
			drawLine.SetActive (false);
			tutorialText.SetActive(false);
		}

	}


	#endif
}

