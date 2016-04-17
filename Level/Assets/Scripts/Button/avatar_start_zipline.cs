using UnityEngine;
using System.Collections;

public class avatar_start_zipline : MonoBehaviour {

	public GameObject boyZipping;
	private Rigidbody2D rigid;

	public void StartAvatarPlay() {
		rigid = boyZipping.AddComponent<Rigidbody2D> ();
		rigid.mass = 4.0f;
		rigid.angularDrag = 1.0f;
		rigid.gravityScale = 2.0f;
	}

	// Use this for initialization
	void Start () {
		boyZipping = GameObject.Find ("BoyZipping");
	}
	
	// Update is called once per frame
	void Update () {

	}
		
}
