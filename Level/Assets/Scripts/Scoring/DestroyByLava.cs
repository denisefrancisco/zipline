using UnityEngine;
using System.Collections;

public class DestroyByLava : MonoBehaviour {

	public GameObject explosion;
	public AudioClip lavaSound;
	private AudioSource lavaSoundSource;
	private GameObject player;
	public GameObject lose_panel;
	private EdgeCollider2D bc;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Avatar");
		bc = player.GetComponent<EdgeCollider2D> ();
		lavaSoundSource = gameObject.GetComponent<AudioSource> ();

	}

	//	void OnTriggerEnter2D(Collider2D other) {
	//		Debug.Log ("TRIGGERED!");
	//		Instantiate(explosion, transform.position, transform.rotation);
	//		Destroy (gameObject);
	//	}
	void lose() {
		lose_panel.SetActive (true);	// Activate lose modal
	}

	IEnumerator wait() {
		lavaSoundSource.PlayOneShot (lavaSound, 1);
		destroyObject ();
		yield return new WaitForSeconds (0.85f);
		lose ();
	}

	void destroyObject () {
		Instantiate (explosion, player.transform.position, player.transform.rotation);
		player.SetActive (false);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (bc.IsTouching (gameObject.GetComponent<BoxCollider2D> ())) {
			Debug.Log ("FELL INTO LAVA " + gameObject.name + " - You lose!");
			// Stop timer
			GameObject.FindGameObjectWithTag ("Timer").GetComponent<myTimer> ().StopTimer ();
			// Destroy avatar and activate lose panel
			StartCoroutine (wait ());
		}
	}
}
