using UnityEngine;
using System.Collections;

public class enableLineDrawing : MonoBehaviour {

	public GameObject zipline;
	private bool enabled;

	void OnMouseDown(){
		Debug.Log ("weee");
		Debug.Log(enabled);
		zipline.GetComponent<DrawPhysicsLine> ().enabled = !enabled;
	}

	// Use this for initialization
	void Start () {
		enabled = false;
		Debug.Log (enabled);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
