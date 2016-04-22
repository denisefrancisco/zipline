using UnityEngine;
using System.Collections;

public class level_success : MonoBehaviour {

	public GameObject avatar;
	public GameObject success_modal;
	public GameObject confetti;
	private EdgeCollider2D ec;
	private BoxCollider2D bc;
	private Vector3 offset;
	private Vector3 offset1;

	// Use this for initialization
	void Start () {
		bc = gameObject.GetComponent<BoxCollider2D> ();
		ec = avatar.GetComponent<EdgeCollider2D> ();
		offset = new Vector3(-1,4,0);
		offset1 = new Vector3(1,4,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (bc.IsTouching(ec)) {
			Debug.Log ("YAYYYY");
			success_modal.SetActive(true);
			Instantiate (confetti, success_modal.transform.position+offset, success_modal.transform.rotation);
			Instantiate (confetti, success_modal.transform.position+offset1,success_modal.transform.rotation);
			avatar.SetActive (false);
		}
	
	}
}
