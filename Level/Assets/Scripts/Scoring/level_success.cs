using UnityEngine;
using System.Collections;

public class level_success : MonoBehaviour {
	//this file is for everything that happens during a successful level completion
	public GameObject avatar;
	//the success popup
	public GameObject success_modal;
	//the confetti prefab that is instantiated when the win function is active
	public GameObject confetti;
	//edge collider of the ziplining avatar
	private EdgeCollider2D ec;
	//the box collider of the current success door
	private BoxCollider2D bc;
	//get rigid body of the avatar
	private Rigidbody2D rb;
	//these offsets are for the placement of the confetti prefab so that it fills up the screen
	private Vector3 offset;
	private Vector3 offset1;

	// Use this for initialization
	void Start () {
		rb = avatar.GetComponent<Rigidbody2D> ();
		bc = gameObject.GetComponent<BoxCollider2D> ();
		ec = avatar.GetComponent<EdgeCollider2D> ();
		offset = new Vector3(-1,4,0);
		offset1 = new Vector3(1,4,0);
	}
	
	// Update is called once per frame
	void Update () {
		//if the box collider comes into contact with the avatar...
		if (bc.IsTouching(ec)) {
			//set rigid body to isKinematic to pause the avatar
			rb.isKinematic = true;
			//success modal pops up
			success_modal.SetActive(true);
			//instantiate confetti!
			Instantiate (confetti, success_modal.transform.position+offset, success_modal.transform.rotation);
			Instantiate (confetti, success_modal.transform.position+offset1,success_modal.transform.rotation);
//			avatar.SetActive (false);
		}
	
	}
}
