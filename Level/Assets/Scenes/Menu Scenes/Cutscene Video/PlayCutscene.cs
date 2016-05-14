using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayCutscene : MonoBehaviour {

	public MovieTexture movie;
	public GameObject backgroundMusic;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		movie.Play ();
		audio.Play ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Music for Menu Scenes") != null) {
			GameObject.Find ("Music for Menu Scenes").SetActive (false);
		}
		if (Input.GetMouseButtonDown(0) == true) 
		{
			SceneManager.LoadScene ("options_menu");
		}
		if (!movie.isPlaying)
		{
			SceneManager.LoadScene ("options_menu");
		}
	}
}
