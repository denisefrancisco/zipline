using UnityEngine;
using System.Collections;

public class avatar_control : MonoBehaviour {
	//declaring variable for animation body
	private Animator anim;

	// Use this for initialization
	void Start () {
		//initializing animation instance of avatar
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//updating speed characteristic
		anim.speed = 0.5f;
	}
}
