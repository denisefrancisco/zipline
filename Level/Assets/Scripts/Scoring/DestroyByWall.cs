using UnityEngine;
using System.Collections;

public class DestroyByWall : MonoBehaviour {

	public GameObject explosion;
	public AudioClip explosionSound;
	private AudioSource explosion_source;
	private GameObject player;
	public GameObject lose_panel;
	private EdgeCollider2D bc;

	//This block of initializations refer to the resetting of the avatar after hitting either the left or the right wall
	private start_play_camera setAvatar;
	private enableRebuild reset;
	private ApplySnapPoints snapPoints;
	private playZip_2 resetConditions;
	private enableDrawAndErase actions;
	private Failures resetFrames;
	private start_camera respawn;
	private removeBoxCollider player_box;

	public GameObject main_camera;
	public GameObject play_camera;
	public GameObject failure_music;
	//end of block

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Avatar");


		setAvatar = GameObject.Find("Avatars").GetComponent<start_play_camera> ();
		reset = GameObject.Find ("enableRebuild").GetComponent<enableRebuild> ();
		snapPoints = GameObject.Find ("Snap Points").GetComponent<ApplySnapPoints> ();
		resetConditions = play_camera.GetComponent<playZip_2> ();
		actions = GameObject.Find ("enableBuilding").GetComponent<enableDrawAndErase> ();
		resetFrames = play_camera.GetComponent<Failures> ();
		respawn = main_camera.GetComponent<start_camera> ();
		player_box = player.GetComponent<removeBoxCollider> ();

		bc = player.GetComponent<EdgeCollider2D> ();
		explosion_source = gameObject.GetComponent<AudioSource> ();

	}

	void lose() {
		failure_music.SetActive (false);
		setAvatar.setAvatarActive();
		reset.ResetAvatar ();
		main_camera.SetActive (true);
		play_camera.SetActive (false);
		player_box.resetBoxCollider ();
		snapPoints.applySnapPoint ();
		resetConditions.resetWinAndLose ();
		actions.EnableBuilding ();
		resetFrames.resetFrameCounter ();
		respawn.respawnAvatar ();
	}

	IEnumerator wait() {
		explosion_source.PlayOneShot (explosionSound, 1);
		destroyObject ();
		yield return new WaitForSeconds (0.85f);
		failure_music.SetActive (true);
		yield return new WaitForSeconds (0.85f);
		lose ();
	}

	void destroyObject () {
		Instantiate (explosion, player.transform.position, player.transform.rotation);
		player.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (bc.IsTouching(gameObject.GetComponent<BoxCollider2D>())) {
			Debug.Log ("RAN INTO WALL " + gameObject.name + " - You lose!");
			// Stop timer
			GameObject.FindGameObjectWithTag("Timer").GetComponent<myTimer>().StopTimer();
			// Destroy avatar and activate lose panel
			StartCoroutine (wait ());
		}
	}
}
