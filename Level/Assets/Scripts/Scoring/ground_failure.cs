using UnityEngine;
using System.Collections;

public class ground_failure : MonoBehaviour {

	public GameObject avatar;
	public GameObject lose_modal;
	private BoxCollider2D bc;


	// Use this for initialization
	void Start () {
		bc = gameObject.GetComponent<BoxCollider2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bc.IsTouching(avatar.GetComponent<EdgeCollider2D>())){
			lose_modal.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}
	
}

