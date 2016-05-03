using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class disableAnimation : MonoBehaviour {

	public GameObject canvas;
	// Use this for initialization
	void Start () {
		if (SystemInfo.deviceModel.Contains ("iPad")) {
			foreach (Transform button in canvas.transform) {
				button.GetComponent<Selectable> ().animationTriggers.highlightedTrigger = "None (Sprite)";
			}
		}
			
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
