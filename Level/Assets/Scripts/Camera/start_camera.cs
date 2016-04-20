using UnityEngine;
using System.Collections;

public class start_camera : MonoBehaviour {

	public Camera camera;

	public void returnCamera(){
		camera.orthographicSize = 5;
		//camera.transform.position = new Vector3 (-4.5f, camera.transform.position.y, camera.transform.position.z);
	}

	// Use this for initialization
	void Start () {
		Debug.Log (Time.timeScale);
		camera.orthographicSize = 5;
		//camera.transform.position = new Vector3 (-4.5f, camera.transform.position.y, camera.transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
