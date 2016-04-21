using UnityEngine;
using System.Collections;

public class DestroyByWall : MonoBehaviour {

	public GameObject explosion;
	public GameObject player;
	public GameObject lose_panel;
	private EdgeCollider2D bc;
	// Use this for initialization
	void Start () {
		bc = player.GetComponent<EdgeCollider2D> ();
	
	}

//	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log ("TRIGGERED!");
//		Instantiate(explosion, transform.position, transform.rotation);
//		Destroy (gameObject);
//	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (bc.IsTouching(gameObject.GetComponent<BoxCollider2D>())) {
			Debug.Log("TRIGGERED");
			Instantiate (explosion, player.transform.position, player.transform.rotation);
			Destroy (player);
			lose_panel.SetActive (true);
		}
	}
}
