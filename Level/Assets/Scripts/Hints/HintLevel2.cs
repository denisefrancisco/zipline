using UnityEngine;
using System.Collections;

public class HintLevel2 : MonoBehaviour {

	public Sprite greenPt;		// Green snap point sprite (dark version)
	private GameObject[] points;	// Reference to list of snap points

	// Swaps original red snap point sprite for hint-colored snap point sprite
	public void hint2() {
		foreach (GameObject p in points) {
			if (p.name != "Point2") {	// switch all points' colors to green
				p.GetComponent<SpriteRenderer> ().sprite = greenPt;
			}
		}
	}

	void Start() {
		points = GameObject.FindGameObjectsWithTag("SnapPoint");
	}

}
