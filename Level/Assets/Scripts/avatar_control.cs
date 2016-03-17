using UnityEngine;
using System.Collections;

public class avatar_control : MonoBehaviour {
	//declaring variable for animation body
	private Animator anim;
	private bool isMoving;
	private bool isGrounded = false;
	private float movement_sp = 0.1f;
	public float speed;
	//getting rigidBody component to check if character is grounded
	public Rigidbody2D rb;
	float someScale;

	// Use this for initialization
	void Start () {
		//initializing animation instance of avatar
		anim = gameObject.GetComponent<Animator> ();
		someScale = transform.localScale.x;
		rb = GetComponent<Rigidbody2D> ();
		isGrounded = false;

	}



	// Update is called once per frame
	void Update () {
		//updating speed characteristic
		anim.speed = 1f * speed;
		var v = Input.GetAxis ("Horizontal");
		Debug.Log (v);
		isMoving = false;
		//character movement across horizontal plane, only if grounded
		if (rb.velocity.y == 0) {
			isGrounded = true;
		}
		if ((v > 0) && (isGrounded == true)) {
			isMoving = true;
			speed = 0.5f;
			transform.localScale = new Vector2 (someScale, transform.localScale.y);
			transform.position += Vector3.right * movement_sp;
		} else if ((v < 0) && (isGrounded == true)) {
			isMoving = true;
			speed = 0.5f;
			transform.localScale = new Vector2 (-someScale, transform.localScale.y);
			transform.position += Vector3.left * movement_sp;
		} if (isMoving == false) {
			speed = 0;
		}
	}
}
