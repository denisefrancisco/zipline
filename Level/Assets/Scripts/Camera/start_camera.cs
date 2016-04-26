using UnityEngine;
using System.Collections;

public class start_camera : MonoBehaviour {

	public Camera camera;
	//get avatar's initial position for resetting
	public GameObject avatar;
	//this variable is to indicate where the camera initializes to when the game is started
	private Vector3 resetCameraPosition;
	//set avatar's initial position to a variable
	private Vector3 avatarPos;
	private Quaternion avatarRot;

	public void returnCamera(){
		camera.orthographicSize = 5.5f;
		//return the camera to the top of the screen after restarting level
		camera.transform.position = resetCameraPosition;
	}

	public void respawnAvatar() {
		avatar = (GameObject) Instantiate(avatar,avatarPos,avatarRot);
		Destroy (avatar);

	}

	// Use this for initialization
	void Start () {
		//saving the starting position for the camera 
		resetCameraPosition = gameObject.transform.position;
		camera.orthographicSize = 5.5f;
		avatarPos = avatar.transform.position;
		avatarRot = avatar.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
