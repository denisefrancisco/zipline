using UnityEngine;
using System.Collections;

public class enableRebuild : MonoBehaviour {

	public GameObject avatar;
	private Rigidbody2D rigid;
	private Vector3 startPos;
	private Quaternion startRot;
	private animOnButton animScript; //animation script attached to avatar
	private SpriteRenderer sprite;

	public void ResetAvatar() {
		/* Set avatar's rigidbody to kinematic so avatar 
		 * can't interact with physics during build mode
		 * (kinematic will be disabled after play button press) */
		rigid = avatar.GetComponent<Rigidbody2D>();
		rigid.isKinematic = true;

		// Reset avatar's position to original position
		avatar.transform.position = startPos;
		avatar.transform.rotation = startRot;

		// Reset flag for avatar's direction (from animScript)
		animScript.facingRight = true;

		//resetting the avatar's flip components in the sprite renderer
		sprite.flipX = false;

	}

	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar"); //initialize avatar GO

		//initialize original position and rotation of avatar transform
		startPos = avatar.transform.position;
		startRot = avatar.transform.rotation;

		// Save reference to animation script
		animScript = avatar.GetComponent<animOnButton> ();

		//getting the sprite renderer component of the avatar to turn off his flip x
		sprite = avatar.GetComponent<SpriteRenderer>();
	}

}
