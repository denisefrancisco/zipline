using UnityEngine;
using System.Collections;

public class avatar_start_zipline : MonoBehaviour {

	public GameObject boyZipping;
	private Rigidbody2D rigid;
//	public void start_zip();

	void OnClick() {
		Debug.Log ("you pressed space!");
		Rigidbody2D rigid = boyZipping.AddComponent<Rigidbody2D> ();
		rigid.mass = 4.0f;
		rigid.angularDrag = 1.0f;
		rigid.gravityScale = 1.0f;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

//	void start_zip() {
//		if (Input.GetKeyDown (KeyCode.Space) == true) {
//			Debug.Log ("you pressed space!");
//			Rigidbody2D rigid = boyZipping.AddComponent<Rigidbody2D> ();
//			rigid.mass = 4.0f;
//			rigid.angularDrag = 1.0f;
//			rigid.gravityScale = 1.0f;
//
//		}
//	}
//
		
}
