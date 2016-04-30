using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour {

	//a boolean that starts a false when the menu music isn't playing
	private bool audioBegin = false;
	//music for the main menu
	public AudioClip menuMusic;
	private AudioSource musicSource;

	void Awake(){
		musicSource = gameObject.GetComponent<AudioSource> ();
		if (!audioBegin) {
			musicSource.Play ();
			DontDestroyOnLoad (gameObject);
			audioBegin = true;
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log (SceneManager.GetActiveScene().name);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "map_level") {
			musicSource.Stop ();
			audioBegin = false;
		}
	}
}
