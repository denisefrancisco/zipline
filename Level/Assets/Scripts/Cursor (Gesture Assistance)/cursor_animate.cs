using UnityEngine;
using System.Collections;

public class cursor_animate : MonoBehaviour {

	public float speed;
	private Vector3 point1;
	public Transform point2;
	private Vector3 end_point = new Vector3 (1,-0.65f,1);
	private float time;
	// Use this for initialization
	void Start () {
		point1 = gameObject.transform.position;
//		gameObject.transform.position = point1.transform.position;
		end_point = Vector3.Scale (point2.position, end_point);
	
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (1);
		Debug.Log ("load");
		transform.position = point1;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= end_point.x) {
//			transform.position = point2.transform.position;
			StartCoroutine (wait ());
		} else {
			transform.Translate ( end_point * Time.deltaTime, Space.World);
		}
	}
}
