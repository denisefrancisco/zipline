using UnityEngine;
using System.Collections;

public class animOnButton : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim.GetComponent<Animation>;
	}
	void OnTriggerEnter2D (Collider2D other) {
		anim.SetTrigger ("onZip");
	
	}
	// Update is called once per frame
	void Update () {
		
	}
}
