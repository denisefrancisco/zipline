using UnityEngine;
using System.Collections;

public class failure_build : MonoBehaviour {

	public AudioClip failureSound;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource> ();
	}

	public void failure_build_sound(){
		source.PlayOneShot (failureSound, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
