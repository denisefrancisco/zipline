using UnityEngine;
using System.Collections;

public class level_success : MonoBehaviour {

	public GameObject avatar;
	public GameObject success_modal;
	public GameObject lose_modal;
	public GameObject confetti;
	private EdgeCollider2D ec;
	private BoxCollider2D bc;

	// Use this for initialization
	void Start () {
		bc = gameObject.GetComponent<BoxCollider2D> ();
		ec = avatar.GetComponent<EdgeCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bc.IsTouching(ec)) {
			Debug.Log ("YAYYYY");
			success_modal.SetActive(true);
			Instantiate (confetti, success_modal.transform.position, success_modal.transform.rotation);
			Time.timeScale = 0.0f;
		}
	
	}
}
