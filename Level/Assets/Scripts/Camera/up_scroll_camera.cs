using UnityEngine;
using System.Collections;

public class up_scroll_camera : MonoBehaviour {

	//	public Transform farLeft;
	//	public Transform farRight;
	public Transform farUp;
	public Transform farDown;
	public Camera mainCamera;
	private Vector3 current_pos;

	// Use this for initialization
	void Start () {
//		mainCamera.transform.position = new Vector3(-3.8f,mainCamera.transform.position.y,mainCamera.transform.position.z);
	}

	void OnMouseDrag() {
		if (mainCamera.transform.position.y + 0.2f <= farUp.position.y) {
			current_pos = mainCamera.transform.position;
			current_pos.y += 0.1f;
			mainCamera.transform.position = current_pos;
		}
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow) == true) {
			current_pos = mainCamera.transform.position;
			current_pos.y += 0.1f;
			mainCamera.transform.position = current_pos;	
		}
	}

}