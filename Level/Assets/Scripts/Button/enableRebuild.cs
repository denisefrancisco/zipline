using UnityEngine;
using System.Collections;

public class enableRebuild : MonoBehaviour {

	public GameObject avatar;
	private Rigidbody2D rigid;
	private Vector3 startPos;
	private Quaternion startRot;

	public void ResetAvatar() {
		/* Destroy avatar's rigidbody so avatar can't interact
		 * with physics during build mode (rigidbody will be
		 * reapplied after play button press*/
		rigid = avatar.GetComponent<Rigidbody2D>();
		Destroy(rigid);

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
