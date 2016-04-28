using UnityEngine;
using System.Collections;

public class Destroy_Saved_Data : MonoBehaviour {

	private GameObject saved_data;
	private GameObject boy;
	private GameObject girl;
	// Use this for initialization
	void Start () {
		
	}

	public void DeleteSavedData(){
		saved_data = GameObject.Find ("Saved Data");
		boy = GameObject.Find ("Boy");
		if (boy == null) {
			girl = GameObject.Find ("girl");
			Destroy (girl);
		} else {
			Destroy (boy);
		}
		Destroy (saved_data);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
