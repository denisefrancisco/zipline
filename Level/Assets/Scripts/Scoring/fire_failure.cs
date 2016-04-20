using UnityEngine;
using System.Collections;

public class fire_failure : MonoBehaviour {
	//checking if the player touches fire at all
	public GameObject player;
	private EdgeCollider2D ec;
	private CircleCollider2D circle;

	// Use this for initialization
	void Start () {
		circle = gameObject.GetComponent<CircleCollider2D> ();
		ec = player.GetComponent<EdgeCollider2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (circle.IsTouching (ec)) {
			Debug.Log ("You touched the fire! You lose!");
		}
	}
}
