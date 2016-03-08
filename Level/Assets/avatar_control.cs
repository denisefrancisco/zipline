using UnityEngine;
using System.Collections;

public class avatar_control : MonoBehaviour {
	//declaring variable for animation body
	private Animator anim;
	public float speed;
	private float movement_sp = 0.1f;
	float someScale;

	// Use this for initialization
	void Start () {
		//initializing animation instance of avatar
		anim = gameObject.GetComponent<Animator> ();
		someScale = transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
		//updating speed characteristic
		anim.speed = 1f * speed;
		var v = Input.GetAxis ("Horizontal");
		Debug.Log ("Horizontal is");
		Debug.Log (v);
		//character movement across horizontal plane
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.localScale = new Vector2(someScale, transform.localScale.y);
			transform.position += Vector3.right * movement_sp;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.localScale = new Vector2(-someScale, transform.localScale.y);
			transform.position += Vector3.left * movement_sp;
		}
	}
		
}
