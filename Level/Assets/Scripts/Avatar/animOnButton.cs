using UnityEngine;
using System.Collections;

public class animOnButton : MonoBehaviour {
	public GameObject avatar;
	public Animator anim;
	private bool go = false;
	private float movement_sp = 2.2f;
	private Collider2D feet;
	public Collider2D origin;
	private Rigidbody2D rb;
	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
		feet = GetComponent<BoxCollider2D> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	/*This trigger is a parameter in the animator.
		*it is used to discern when the player is on the zip line
		*and will trigger the animation to become avatar holding trolley.
		*/
//	void OnTriggerEnter2D (Collider2D other) {
//		anim.SetTrigger ("onZip");
//	
//	
	public void OnClick() {
		Debug.Log ("hello");
		anim.SetTrigger ("onClick");
		go = true;
	}
	void OnTriggerEnter2D (Collider2D other) {
	
		anim.SetTrigger ("onZip");
	
	}
	// Update is called once per frame
	void Update () {
		if (go) {
			if (feet.IsTouching(origin)){ 				
				rb.AddForce (Vector3.right * movement_sp, ForceMode2D.Impulse); // += Vector3.right * movement_sp;
			}

	}
}
}
	//anim.Play(anim.clip.name);

