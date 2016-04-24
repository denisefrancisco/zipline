using UnityEngine;
using System.Collections;

public class start_camera : MonoBehaviour {

	public Camera camera;
	//this variable is to indicate where the camera initializes to when the game is started
	private Vector3 resetCameraPosition;

	public void returnCamera(){
		camera.orthographicSize = 5.5f;
		//return the camera to the top of the screen after restarting level
		camera.transform.position = resetCameraPosition;
	}

	// Use this for initialization
	void Start () {
		//saving the starting position for the camera 
		resetCameraPosition = gameObject.transform.position;
		camera.orthographicSize = 5.5f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
