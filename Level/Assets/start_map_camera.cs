using UnityEngine;
using System.Collections;

public class start_map_camera : MonoBehaviour {

	private GameObject boy;
	// Use this for initialization
	void Start () {
		boy = GameObject.Find ("Boy");
		boy.transform.position = new Vector3 (0, 0, 100);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
