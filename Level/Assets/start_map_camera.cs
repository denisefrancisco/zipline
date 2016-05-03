using UnityEngine;
using System.Collections;

public class start_map_camera : MonoBehaviour {

	private GameObject player;
	private GameObject backgroundMusic;
	public AudioClip audioSound;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Boy");
		if (GameObject.Find ("Music For Menu Scenes") == null) {
			backgroundMusic = new GameObject ();
			backgroundMusic.name = "Music For Menu Scenes";
			backgroundMusic.AddComponent<AudioSource> ().clip = audioSound;
			backgroundMusic.AddComponent<AudioSource> ().playOnAwake = true;
			backgroundMusic.AddComponent<AudioSource> ().loop = true;
			backgroundMusic.AddComponent<MenuMusic> ().menuMusic = audioSound;
		}
		if (player == null) {
			player = GameObject.Find ("girl");
			player.transform.position = new Vector3 (0, 0, 100);
		} else {
			player.transform.position = new Vector3 (0, 0, 100);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
