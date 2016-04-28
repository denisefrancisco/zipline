using UnityEngine;
using System.Collections;

public class playZip_2 : MonoBehaviour {

	private Transform player;
	//these Transforms are for indicating how far the camera will go width-wise to follow the player
	public Transform farLeft;
	public Transform farRight;
	//the clock that has been set in order to complete the level (within certain time)
	public GameObject timer;
	public GameObject lose_panel;
	public GameObject win_panel;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Avatar").GetComponent<Transform> ();
		timer.SetActive (false);
	}
		
	public void resetWinAndLose(){
		lose_panel.SetActive (false);
		win_panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = player.position.x;
		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		newPosition.y = player.position.y;
		transform.position = newPosition;
		//if the avatar is past the x coordinate of the first point...start timer.
		if (player.transform.position.x >= -3.2f) {
			timer.SetActive (true);
		}

	}
}
