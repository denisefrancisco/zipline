using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	private bool inZone;	// Flag indicating avatar is in the landing zone
	private bool pastZone;	// Flag indicating avatar has passed the landing zone
	private float speed;	// Avatar's speed (technically velocity magnitude)
	private int score;		// Player's score, dependent on avatar stopping in landing zone
	public GameObject avatar;	// Reference to avatar GO
	private Rigidbody2D rigid;	// Reference to avatar GO's rigidbody2d component
	private FloorZone floorZone;	// Reference to floorZone script

	void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("entered landing zone at speed" + speed);
		inZone = true;	// Avatar in landing zone
	}

	void OnTriggerExit2D (Collider2D other) {
		// Avatar left landing zone, now past landing zone
		Debug.Log ("exited landing zone");
		inZone = false;	
		pastZone = true;
	}

	public void EndPlay (int outcomeID) {
		// Reset flags
		inZone = false;
		pastZone = false;
		floorZone.inFloorZone = false;
		// Print outcome
		if (outcomeID == 1) {
			// Stagnation
			Debug.Log ("Failure: You slowed down before reaching the table.");
		}  else if (outcomeID == 2) {
			// Fell off
			Debug.Log ("Failure: You fell off before reaching the table.");
		}  else if (outcomeID == 3) {
			// Flew past
			Debug.Log ("Failure: You flew past the table.");
		}  else if (outcomeID == 4) {
			// Success
			Debug.Log ("Success: You earned a score of " + score + ".");
		}
	}

	// Use this for initialization
	void Start () {
		// Initialize avatar and rigidbody component
		avatar = GameObject.Find ("BoyZipping");
		rigid = avatar.GetComponent<Rigidbody2D> ();
		// Initialize reference to floorZone script
		floorZone = GameObject.Find ("FloorZone").GetComponent<FloorZone> ();
		// Initialize boolean flags to false
		inZone = false;
		pastZone = false;
		// Calculate portions of landing zone that produce different scores
		/* zoneStartX = ;
		 * zoneEndX = ;
		 * zoneWidth = ;
		 * oneStar = ;
		 * twoStar = ;
		 * threeStar = zoneEndX;*/
		// Initialize score
		score = 0;
	}

	void FixedUpdate ()	 {
		speed = rigid.velocity.magnitude;
		if (speed == 0.0) {
			if (inZone) {
				// UPDATE SCORE
				score = 1;
				EndPlay (4);
			}  else {
				EndPlay (1); // Stagnant
			}
		}  else {
			if (floorZone.inFloorZone) {
				if (pastZone) {
					EndPlay (3); // Flew past zipline
				}  else {
					EndPlay (2); // Fell off zipline
				}
			}
		}
	}

}
