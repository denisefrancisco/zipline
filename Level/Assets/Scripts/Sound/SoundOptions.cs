using UnityEngine;
using System.Collections;

public class SoundOptions : MonoBehaviour {

	// Flag indicating whether sound is on
	public bool soundIsOn;
	// Reference to last sound volume level before turned off
	private float sVolume;

	public void SoundOn() {
		soundIsOn = true;
		AudioListener.volume = sVolume;
	}

	public void SoundOff() {
		soundIsOn = false;
		// Save current sound volume level before turning sound off
		sVolume = AudioListener.volume;
		AudioListener.volume = 0.0f;
	}

	// TODO: Implement Music controls once we implement music
	/*public void MusicOn() {
	}
	public void MusicOff() {
	}*/

	// Use this for initialization
	void Start () {
		// Initially sound is on
		sVolume = AudioListener.volume;
		if (sVolume > 0f) {
			soundIsOn = true;
		} else {
			soundIsOn = false;
		}
	}

}
