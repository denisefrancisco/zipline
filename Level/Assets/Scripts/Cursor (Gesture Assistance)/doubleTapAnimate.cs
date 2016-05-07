using UnityEngine;
using System.Collections;

public class doubleTapAnimate : MonoBehaviour {
	#if UNITY_STANDALONE_OSX
	public float speed;
	private Vector3 cursor;
	public Transform buttonClick;
	private TrailRenderer drawLine;
	public Transform point2;
	private Vector3 end_point = new Vector3 (2.4f,0,1);
	private float time;
	// Use this for initialization
	void Start () {
		drawLine = GameObject.Find ("trailRendererStart").GetComponent<TrailRenderer> ();
		cursor = gameObject.transform.position;
		end_point = Vector3.Scale (point2.position, end_point);
		buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);

	}

	IEnumerator wait(){
		yield return new WaitForSeconds (1);
		Debug.Log ("load");
		buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,2);
		yield return new WaitForSeconds (1);
		transform.position = cursor;
		buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
		drawLine.Clear ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) == false) {
			if (transform.position.x >= end_point.x) {
				StartCoroutine (wait ());
			} else {
				transform.Translate (end_point * Time.deltaTime, Space.World);
			}
		} else {
			gameObject.SetActive (false);
		}
	}

	#endif
}

