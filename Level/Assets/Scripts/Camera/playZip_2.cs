using UnityEngine;
using System.Collections;

public class playZip_2 : MonoBehaviour {

	// Avatar GO's transform component
	public Transform player;
	// These indicate how far the camera will go width-wise to follow the avatar's movement
	public Transform farLeft;
	public Transform farRight;
	// Reference to timer GO displaying zipline traversal time
	public GameObject timer;
	// Reference to win and lose modal GOs
	public GameObject lose_panel;
	public GameObject win_panel;

	// Use this for initialization
	void Start () {
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
