using UnityEngine;
using System.Collections;

public class HintLevel3 : MonoBehaviour {

	// Green snap point sprite (dark version)
	public Sprite greenPt;

	// Swaps original red snap point sprite for hint-colored snap point sprite
	public void hint3() {
		GameObject.Find ("Point1").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point2").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point5").GetComponent<SpriteRenderer> ().sprite = greenPt;
	}

}
