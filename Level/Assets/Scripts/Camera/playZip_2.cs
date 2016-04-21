using UnityEngine;
using System.Collections;

public class playZip_2 : MonoBehaviour {

	public Transform player;
	public Transform farLeft;
	public Transform farRight;
	public GameObject timer;
	public GameObject lose_panel;
	public GameObject win_panel;

	// Use this for initialization
	void Start () {
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
		if (player.transform.position.x >= -3.2f) {
			timer.SetActive (true);
		}

	}
}
