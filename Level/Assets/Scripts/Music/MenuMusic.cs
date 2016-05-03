using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuMusic : MonoBehaviour {

	//a boolean that starts a false when the menu music isn't playing
	private bool audioBegin = false;
	//music for the main menu
	public AudioClip menuMusic;
	private AudioSource musicSource;
	private string[] levelList = new string[6];

	void Awake(){
		musicSource = gameObject.GetComponent<AudioSource> ();
		musicSource.Play ();
		DontDestroyOnLoad (gameObject);
		if (GameObject.FindGameObjectsWithTag("Music").Length > 1){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		levelList [0] = "LabLevel1";
		levelList [1] = "LabLevel2";
		levelList [2] = "LabLevel3";
		levelList [3] = "LabLevel4";
		levelList [4] = "LivingRoomLevel5";
		levelList [5] = "LivingRoomLevel6";
		Debug.Log (SceneManager.GetActiveScene().name);
	}
	
	// Update is called once per frame
	void Update () {
//		if (SceneManager.GetActiveScene().name == "map_level") {
//			musicSource.Stop ();
//			audioBegin = false;
//		}
		foreach (string x in levelList) {
			if (SceneManager.GetActiveScene().name == x) {
				musicSource.Stop ();
			}
		}
	}
}
