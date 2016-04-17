using UnityEngine;
using System.Collections;

public class avatar_start_zipline : MonoBehaviour {

	public GameObject boyZipping;
	private Rigidbody2D rigid;

	public void StartAvatarPlay() {
		rigid.isKinematic = false;	// Apply Unity physics to avatar rigidbody
		/*rigid.mass = 4.0f;
		rigid.angularDrag = 1.0f;
		rigid.gravityScale = 1.0f;*/
	}

	// Use this for initialization
	void Start () {
		// Initialize avatar GO and rigidbody component
		boyZipping = GameObject.Find ("BoyZipping");
		rigid = boyZipping.GetComponent<Rigidbody2D> ();
	}
		
}
