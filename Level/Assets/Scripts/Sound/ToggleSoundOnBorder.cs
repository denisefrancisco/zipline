using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleSoundOnBorder : MonoBehaviour {

	private Button b;
	private SoundOptions soundScript; // script reference
	private bool hasBorder;	// Flag for displaying border
	// Reference to GO with border sprite
	private Image border;

	// Use this for initialization
	void Start () {
		// Get the button's child that already has border sprite
		border = GameObject.Find("SOnBorder").GetComponent<Image>();
		// Save a reference to button
		soundScript = GameObject.Find ("ButtonScripts").GetComponent<SoundOptions>();

		// Initially "Sound On" button is selected, so border is visible
		border.enabled = true;
		hasBorder = true;
	}
	
	// Update is called once per frame
	void Update () {
		// If sound is on, border appears on "sound on" button
		if (soundScript.soundIsOn && !hasBorder) {
			border.enabled = true;
			hasBorder = true;
		} else if (!soundScript.soundIsOn && hasBorder) {
			border.enabled = false;
			hasBorder = false;
		}
	}
}
