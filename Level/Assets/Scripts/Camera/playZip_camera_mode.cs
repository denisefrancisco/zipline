using UnityEngine;
using System.Collections;

public class playZip_camera_mode : MonoBehaviour {

	public GameObject player;
	public Camera allcameraData;
	private Vector3 offset = new Vector3 (0,12,-40);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform characterTransform = player.transform;
		Vector3 characterPosition = characterTransform.position;
		allcameraData.transform.position = characterPosition + offset;
	}
}
