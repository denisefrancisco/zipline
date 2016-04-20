using UnityEngine;
using System.Collections;

public class removeBoxCollider : MonoBehaviour {

	//this is for getting the public variable timerCount in order to reset the timer.
	public myTimer timer;
	public GameObject player;
	//box collider of the box collider that allows the avatar to walk onto the zipline
	private BoxCollider2D bc;

	// Use this for initialization
	void Start () {
		bc = player.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public void resetBoxCollider() {
		Time.timeScale = 0.6f;
		timer.myCoolTimer = 0.0f;
		bc.isTrigger = false;
	}
	//this is to remove the rigid body during game start
	void FixedUpdate() {
		if (player.transform.position.x > -3.2f) {
			bc.isTrigger = true;
		}
	}
}
