using UnityEngine;
using System.Collections;

public class avatar_jump : MonoBehaviour {

	private Animator anim;
	public float speed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		anim.speed = 1f * speed;

	}
}
