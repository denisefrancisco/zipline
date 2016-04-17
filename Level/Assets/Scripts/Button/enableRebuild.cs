using UnityEngine;
using System.Collections;

public class enableRebuild : MonoBehaviour {

	public GameObject avatar;
	private Rigidbody2D rigid;
	private Vector3 startPos;
	private Quaternion startRot;

	public void ResetAvatar() {
		/* Set avatar's rigidbody to kinematic so avatar 
		 * can't interact with physics during build mode
		 * (kinematic will be disabled after play button press) */
		rigid = avatar.GetComponent<Rigidbody2D>();
		rigid.isKinematic = true;

		// Reset avatar's position to original position
		avatar.transform.position = startPos;
		avatar.transform.rotation = startRot;
	}

	// Use this for initialization
	void Start () {
		avatar = GameObject.Find ("BoyZipping"); //initialize avatar GO
		//initialize original position and rotation of avatar transform
		startPos = avatar.transform.position;
		startRot = avatar.transform.rotation;
	}

}
