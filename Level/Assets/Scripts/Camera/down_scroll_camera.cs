using UnityEngine;
using System.Collections;

public class down_scroll_camera : MonoBehaviour {
	//these two transforms below are used to reference the boundaries of the level map
	public Transform farUp;
	public Transform farDown;

	public Camera mainCamera;
	private Vector3 current_pos;
	// Use this for initialization
	void Start () {
	}

	void OnMouseDrag() {
		if (mainCamera.transform.position.y - 0.2f >= farDown.position.y) {
			current_pos = mainCamera.transform.position;
			current_pos.y -= 0.1f;
			mainCamera.transform.position = current_pos;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.DownArrow) == true) {
			if (mainCamera.transform.position.y - 0.2f >= farDown.position.y) {
				current_pos = mainCamera.transform.position;
				current_pos.y -= 0.1f;
				mainCamera.transform.position = current_pos;
			}

		}
	}

}
