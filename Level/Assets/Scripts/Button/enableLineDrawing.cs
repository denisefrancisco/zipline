using UnityEngine;
using System.Collections;

public class enableLineDrawing : MonoBehaviour {

	public GameObject zipline;
	private bool enabled;

	void OnMouseDown(){
		Debug.Log ("weee");
		Debug.Log("drawphysicsline enabled?" + enabled);
		//zipline.GetComponent<DrawPhysicsLine> ().enabled = !enabled;
		//temporarily disable this so line drawing works, will fix in next commit
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
