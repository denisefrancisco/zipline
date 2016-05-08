using UnityEngine;
using System.Collections;

public class HintLevel3 : MonoBehaviour {

	// Green snap point sprite (dark version)
	public Sprite greenPt;

	// Swaps original red snap point sprite for hint-colored snap point sprite
	public void hint3() {
		GameObject.Find ("Point7").GetComponent<SpriteRenderer> ().sprite = greenPt;
		GameObject.Find ("Point8").GetComponent<SpriteRenderer> ().sprite = greenPt;
	}

}
