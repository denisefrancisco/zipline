using UnityEngine;
using System.Collections;

public class SoundOptions : MonoBehaviour {

	// Reference to last sound volume level before turned off
	private float sVolume;

	public void SoundOn() {
		AudioListener.volume = sVolume;
		Debug.Log ("turned on sound to " + sVolume);
	}

	public void SoundOff() {
		// Save current sound volume level before turning sound off
		sVolume = AudioListener.volume;
		AudioListener.volume = 0.0f;
		Debug.Log ("turned off sound");
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
		Debug.Log ("current volume" + sVolume);
	}

}
