using UnityEngine;
using System.Collections;

public class start_map_camera : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Boy");

		if (player == null) {
			player = GameObject.Find ("girl");
			player.transform.position = new Vector3 (0, 0, 100);
		} else {
			player.transform.position = new Vector3 (0, 0, 100);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
