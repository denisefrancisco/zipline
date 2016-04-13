using UnityEngine;
using System.Collections;

public class playZip_camera_mode : MonoBehaviour {

	public GameObject player;
	public Camera allcameraData;
	private Vector3 offset = new Vector3 (0,0,-2);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform characterTransform = player.transform;
		Vector3 characterPosition = characterTransform.position;
		Debug.Log (allcameraData.transform.position);
		allcameraData.transform.position = characterPosition + offset;
	}
}
//using UnityEngine;
//using System.Collections;
//
//public class playZip_camera_mode : MonoBehaviour {
//
//	public float dampTime = 0.15f;
//	private Vector3 velocity = Vector3.zero;
//	public Transform target;
//	public Camera camera;
//
//	// Update is called once per frame
//	void Update () 
//	{
//		if (target)
//		{
//			Vector3 point = camera.WorldToViewportPoint(target.position);
//			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
//			Vector3 destination = transform.position + delta;
//			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
//		}
//
//	}
//}
