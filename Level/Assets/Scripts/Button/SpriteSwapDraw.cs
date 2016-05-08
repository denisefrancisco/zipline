using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteSwapDraw : MonoBehaviour {

	/*private Button drawButton;	// Button reference
	private enableLineDrawing enableDraw; // EnableDrawing script reference
	private bool spriteSwap;	// Flag for swaping sprite
	// References to light and dark versions of draw button sprite
	public Sprite lite;
	public Sprite dark;

	// Use this for initialization
	void Start () {
		spriteSwap = false;
		drawButton = GetComponent<Button> ();
		enableDraw = GameObject.Find ("enableLineDrawing").GetComponent<enableLineDrawing>();
	}
	
	// Update is called once per frame
	void Update () {
		/* If you can draw and haven't sprite swapped yet, set dark sprite
		 * If you can't draw and have already swapped sprites,  set lite sprite */
		/*if (enableDraw.canDraw && !spriteSwap) {
			drawButton.image.overrideSprite = dark;
			spriteSwap = true;
		} else if (!enableDraw.canDraw && spriteSwap) {
			drawButton.image.overrideSprite = lite;
			spriteSwap = false;
		}
	}*/
}
