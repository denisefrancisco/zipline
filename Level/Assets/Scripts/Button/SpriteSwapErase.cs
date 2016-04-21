using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteSwapErase : MonoBehaviour {

	private Button eraseButton;	// Button reference
	private enableLineErasing enableErase; // EnableErasing script reference
	private bool spriteSwap;	// Flag for swaping sprite
	// References to light and dark versions of erase button sprite
	public Sprite lite;
	public Sprite dark;

	// Use this for initialization
	void Start () {
		spriteSwap = false;
		eraseButton = GetComponent<Button> ();
		enableErase = GameObject.Find ("enableLineErasing").GetComponent<enableLineErasing>();
	}

	// Update is called once per frame
	void Update () {
		/* If you can erase and haven't sprite swapped yet, set dark sprite
		 * If you can't erase and have already swapped sprites,  set lite sprite */
		if (enableErase.canErase && !spriteSwap) {
			eraseButton.image.overrideSprite = dark;
			Debug.Log ("erase button dark");
			spriteSwap = true;
		} else if (!enableErase.canErase && spriteSwap){
			eraseButton.image.overrideSprite = lite;
			Debug.Log ("erase button lite");
			spriteSwap = false;
		}
	}
}
