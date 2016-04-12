using UnityEngine;
using System.Collections;

public class animOnButton : MonoBehaviour {
	public GameObject avatar;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim.GetComponent<Animation> ();
	}
	/*This trigger is a parameter in the animator.
		*it is used to discern when the player is on the zip line
		*and will trigger the animation to become avatar holding trolley.
		*/
//	void OnTriggerEnter2D (Collider2D other) {
//		anim.SetTrigger ("onZip");
//	
//	}
	void OnClick() {
		Rigidbody2D rigid = avatar.AddComponent<Rigidbody2D> ();
		rigid.mass = 4.0f;
		rigid.angularDrag = 1.0f;
		rigid.gravityScale = 1.0f;
	}
	void OnTriggerEnter2D (Collider2D other) {
	
		anim.SetTrigger ("onClick");
	
	}
	// Update is called once per frame
	void Update () {
		
	}
}

	//anim.Play(anim.clip.name);

