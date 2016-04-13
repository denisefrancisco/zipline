using UnityEngine;
using System.Collections;

public class change_camera : MonoBehaviour {

	public Camera buildCam;
	//public Camera playCam;

	// Use this for initialization
	void Start () {
		buildCam.enabled = true;
		//playCam.enabled = false;
	}

	public void changeCam () {
		buildCam.enabled = !buildCam.enabled;
		//playCam.enabled = !playCam.enabled;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
	