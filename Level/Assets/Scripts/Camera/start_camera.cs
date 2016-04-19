using UnityEngine;
using System.Collections;

public class start_camera : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () {
		camera.orthographicSize = 5;
		camera.transform.position = new Vector3 (-5.0f, camera.transform.position.y, camera.transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
