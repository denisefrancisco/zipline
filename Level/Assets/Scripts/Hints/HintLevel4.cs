using UnityEngine;
using System.Collections;

public class HintLevel4 : MonoBehaviour {

	// All other snap point sprites (dark versions)
	public Sprite greenPt;

	// Swaps original red snap point sprite for hint-colored snap point sprite
	public void hint4() {
		GameObject.Find ("Point3").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point4").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point5").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point6").GetComponent<SpriteRenderer> ().sprite = greenPt;
	}
}
