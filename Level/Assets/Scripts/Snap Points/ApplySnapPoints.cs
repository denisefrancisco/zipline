using UnityEngine;
using System.Collections;

public class ApplySnapPoints : MonoBehaviour {

	public void applySnapPoint() {
		foreach (Transform child in this.transform) {
			child.gameObject.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {

	}
}