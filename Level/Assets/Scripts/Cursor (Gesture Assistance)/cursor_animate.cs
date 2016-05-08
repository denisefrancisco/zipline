using UnityEngine;
using System.Collections;

public class cursor_animate : MonoBehaviour {
	/*DESCRIPTION: This script is used for the click and drag tutorial, animated gesture. (creating a line action)
	 * MODIFIED: May 7th, 2016
	*/
	#if UNITY_STANDALONE_OSX
	//The cursor gameobject refers to the big El Capitan cursor on the screen
	private Vector3 cursor;
	//The drawLine refers to the trail renderer component that acts as a demo zipline
	private TrailRenderer drawLine;
	//This end_point position is hardcoded. Refers to the position of the second snap point closest to the door
	private Vector3 end_point = new Vector3 (1.7f,-1.13f,1);

	//The play arrow refers to the arrow object pointing to the play button after the player starts interacting with the game
	public GameObject playArrow;
	//The tutorial text is the piece of text below the two snap points.
	public GameObject tutorialText;
	//The buttonClick refers to the sprite that has a blue highlighted left button mouse click 
	public Transform buttonClick;
	//point 2 refers to the second snap point on the game screen (Scene: LabLevel1)
	public Transform point2;


	void Awake() {
		StartCoroutine ("SetGuard");
	}

	// Use this for initialization
	void Start () {
		//initialize the placements of the tutorial game object gestures
		drawLine = GameObject.Find ("trailRendererStart").GetComponent<TrailRenderer> ();
		cursor = gameObject.transform.position;
		end_point = Vector3.Scale (point2.position, end_point);
		buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
		
	}

	IEnumerator SetGuard(){
		//In order to have the animated tutorial gestures on repeat, it is put under a while loop.
		while (true){
			//in order to show a "click" the buttonClick sprite goes in front of the mouse sprite and back.
			yield return new WaitForSeconds (3);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,2);
			yield return new WaitForSeconds (1);
			transform.position = cursor;
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
			//while resetting the tutorial animation, the trail renderer is reset.
			drawLine.Clear ();
		}
	}

	//Once the player clicks on the play button, the play arrow disappears.
	public void playArrowOff() {
		playArrow.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		//if the player decides to interact with the UI, all tutorial gesture animations are set inactive.
		if (Input.GetMouseButton (0) == true) {
			playArrow.SetActive (true);
			gameObject.SetActive (false);
			tutorialText.SetActive(false);
		}
		else
		{
			if (transform.position.x <= end_point.x) {
				transform.Translate (end_point * Time.deltaTime, Space.World);
			}
		}
	}

	#endif
}

