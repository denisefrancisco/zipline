using UnityEngine;
using System.Collections;

public class button_click : MonoBehaviour {

	public AudioClip buttonSound;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();
	}

	public void click_button(){
		source.PlayOneShot(buttonSound,1f);
	}

	// Update is called once per frame
	void Update () {

	}
}
