using UnityEngine;
using System.Collections;

public class cursor_animate : MonoBehaviour {
	#if UNITY_STANDALONE_OSX

	private Vector3 cursor;
	private TrailRenderer drawLine;
	private Vector3 end_point = new Vector3 (1.7f,-1.13f,1);
	private float time;

	public GameObject playArrow;
	public GameObject tutorialText;
	public Transform buttonClick;
	public Transform point2;


	void Awake() {
		StartCoroutine ("SetGuard");
	}

	// Use this for initialization
	void Start () {
		drawLine = GameObject.Find ("trailRendererStart").GetComponent<TrailRenderer> ();
		cursor = gameObject.transform.position;
		end_point = Vector3.Scale (point2.position, end_point);
		buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
		
	}

	IEnumerator SetGuard(){
		while (true){
			yield return new WaitForSeconds (3);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,2);
			yield return new WaitForSeconds (1);
			transform.position = cursor;
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
			drawLine.Clear ();
		}
	}

	public void playArrowOff() {
		playArrow.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
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

