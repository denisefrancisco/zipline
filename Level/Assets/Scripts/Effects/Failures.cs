using UnityEngine;
using System.Collections;

public class Failures : MonoBehaviour {

	public GameObject avatar;
	public GameObject lose_panel;
	private Rigidbody2D rb;
	private int frameCounter;
	private float speed;


	// Use this for initialization
	void Start () {
		rb = avatar.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Grab avatar current speed
		speed = rb.velocity.magnitude;
		if (speed == 0f){
			frameCounter++;
			if (frameCounter > 5){
				Debug.Log ("you lose!");
				lose_panel.SetActive(true);
				frameCounter = 0;
			}
		}
	
	}
}
