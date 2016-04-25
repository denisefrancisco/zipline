using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleSoundOffBorder : MonoBehaviour {

	private Button b;
	private SoundOptions soundScript; // script reference
	private bool hasBorder;	// Flag for displaying border
	// Reference to GO with border sprite
	private Image border;

	// Use this for initialization
	void Start () {
		// Get the button's child that already has border sprite
		border = GameObject.Find("SOffBorder").GetComponent<Image>();
		// Save a reference to button
		soundScript = GameObject.Find ("ButtonScripts").GetComponent<SoundOptions>();

		// Initially "Sound Off" button is selected, so border is not visible
		border.enabled = false;
		hasBorder = false;
	}

	// Update is called once per frame
	void Update () {
		// If sound is off, border appears on "sound off" button
		if (!soundScript.soundIsOn && !hasBorder) {
			border.enabled = true;
			hasBorder = true;
		} else if (soundScript.soundIsOn && hasBorder) {
			border.enabled = false;
			hasBorder = false;
		}
	}
}
