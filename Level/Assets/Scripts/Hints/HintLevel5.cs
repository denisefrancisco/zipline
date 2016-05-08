using UnityEngine;
using System.Collections;

public class HintLevel5 : MonoBehaviour {

	// All snap point sprites (dark versions)
	public Sprite greenPt;
	public Sprite bluePt;
	public Sprite greyPt;

	private GameObject[] points;	// Reference to list of snap points
	private enableDrawAndErase enableBuilding;	// Reference to enableDrawAndErase script for building

	// Swaps original red snap point sprite for hint-colored snap point sprite
	public void hint5() {
		Debug.Log ("swapped!");
		GameObject.Find ("Point3").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point4").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point11").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point12").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point13").GetComponent<SpriteRenderer> ().sprite = greyPt;

		GameObject.Find ("Point7").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point8").GetComponent<SpriteRenderer> ().sprite = greenPt;

		GameObject.Find ("Point5").GetComponent<SpriteRenderer> ().sprite = bluePt;
		GameObject.Find ("Point6").GetComponent<SpriteRenderer> ().sprite = bluePt;
	}

	// Use this for initialization
	void Start () {
		points = GameObject.FindGameObjectsWithTag ("SnapPoint");
	}
}
