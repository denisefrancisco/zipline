using UnityEngine;
using System.Collections;

public class avatar_start_zipline : MonoBehaviour {

	public GameObject boyZipping;
	private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) == true){
			Debug.Log ("you pressed space!");
			Rigidbody2D rigid = boyZipping.AddComponent<Rigidbody2D> ();
			rigid.mass = 0.5f;
	
		}
	}
}
