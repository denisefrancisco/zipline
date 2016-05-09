using UnityEngine;
using System.Collections;

public class HintLevel6 : MonoBehaviour {

	// All other snap point sprites (dark versions)
	public Sprite greenPt;
	public Sprite bluePt;
	public Sprite greyPt;
	
	// Swaps original red snap point sprite for hint-colored snap point sprite
	public void hint6() {
		GameObject.Find ("Point3").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point4").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point18").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point20").GetComponent<SpriteRenderer> ().sprite = greyPt;
		GameObject.Find ("Point22").GetComponent<SpriteRenderer> ().sprite = greyPt;

		GameObject.Find ("Point5").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point6").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point7").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point10").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point15").GetComponent<SpriteRenderer> ().sprite = greenPt;

		GameObject.Find ("Point8").GetComponent<SpriteRenderer> ().sprite = bluePt;
		GameObject.Find ("Point9").GetComponent<SpriteRenderer> ().sprite = bluePt;
		GameObject.Find ("Point11").GetComponent<SpriteRenderer> ().sprite = bluePt;
	}
}
