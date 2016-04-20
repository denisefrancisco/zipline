using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	private bool inZone;	// Flag indicating avatar is in the landing zone
	public bool pastZone;	// Flag indicating avatar has passed the landing zone
	/* Flag indicating when to calculate score (i.e. when play mode is ended);
	 * set to true in EndPlay() method here and set to false in enableRebuild script */
	public bool playEnded;
	public GameObject lose_panel;

	private float speed;	// Avatar's speed (technically velocity magnitude)
	private int frameCounter; // Counts number of frames after avatar's speed reaches 0
	private int score;		// Player's score, dependent on avatar stopping in landing zone

	/* x coordinate (in world position) defining right bound
	 * of subregions in landing zone that grant one, two, and three stars */
	private float oneStar;
	private float twoStar;
	private float threeStar;

	public GameObject avatar;	// Reference to avatar GO
	private Rigidbody2D rigid;	// Reference to avatar GO's rigidbody2d component
	private float avatarXPos; 	// Avatar transform's x position
	private FloorZone floorZone;	// Reference to floorZone script


	void OnTriggerEnter2D (Collider2D other) {
		inZone = true;	// Avatar in landing zone
	}


	void OnTriggerExit2D (Collider2D other) {
		// Avatar left landing zone
		inZone = false;	
		/* If play hasn't ended (i.e. score hasn't been calculated yet),
		 * then avatar is still moving past the landing zone */
		if (!playEnded) {
			pastZone = true;
		}
	}


	public void EndPlay (int outcomeID) {
		// raise playEnded flag so fixedUpdate doesn't keep calculating things
		playEnded = true;

		// Print outcome
		if (outcomeID == 1) {
			// Stagnation
			lose_panel.SetActive(true);
			Debug.Log ("Failure: You slowed down at " + avatarXPos + " before reaching the table.");
		}  else if (outcomeID == 2) {
			// Fell off
			lose_panel.SetActive(true);
			Debug.Log ("Failure: You fell off at " + avatarXPos +" before reaching the table.");
		}  else if (outcomeID == 3) {
			// Flew past
			Debug.Log ("Failure: You flew past the table.");
		}  else if (outcomeID == 4) {
			// Success
			Debug.Log ("Success: You earned a score of " + score + ".");
		}

		// Reset flags, score, and outcome
		inZone = false;
		floorZone.inFloorZone = false;
		score = 0;
		outcomeID = 0;
	}


	// Use this for initialization
	void Start () {
		
		// Initialize avatar and rigidbody component
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		rigid = avatar.GetComponent<Rigidbody2D> ();
		// Initialize reference to floorZone script
		floorZone = GameObject.Find("FloorZone").GetComponent<FloorZone> ();

		// Initialize boolean flags to false
		inZone = false;
		pastZone = false;

		score = 0; 		// Initialize score
		frameCounter = 0;	// Initialize counter

		// Calculate portions of landing zone that produce different scores
		BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
		float exts = col.bounds.extents.x;	// Half the width of landing zone box collider
		float width = 2f * exts;		// Width of landing zone box collider
		// X coordinate of landing zone center (in world space)
		float center = col.bounds.center.x;
		// Left and right bounds of landing zone (in world space)
		float leftBound = center - exts;
		float rightBound = center + exts;
		// Right bounds of one-star, two-star, and three-star regions of landing zone
		oneStar = leftBound + (0.5f * width);
		twoStar = leftBound + (0.8f * width);
		threeStar = rightBound;
	}


	void FixedUpdate ()	 {
		//if the avatar hits the wall...
		if (avatar.transform.position.x <= -6.7 || avatar.transform.position.x >= 6.7) {
			lose_panel.SetActive (true);
			Debug.Log ("Avatar that hit the wall! You lose!");
		}

		if (!playEnded) {
			// Grab avatar current speed and x position
			speed = rigid.velocity.magnitude;
			avatarXPos = avatar.transform.position.x;

			// Once avatar speed has reached 0...
			if (speed == 0f) {	
				// Increment counter for every frame we've waited since avatar speed reached 0
				frameCounter++;
				// Once we've waited 5 frames after avatar speed reached 0...
				if (frameCounter > 5) {
					// If avatar stopped in landing zone, calculate score
					if (inZone) {
						// Update score
						if (avatarXPos < oneStar) {
							score = 1;
						} else if (avatarXPos < twoStar) {
							score = 2;
						} else if (avatarXPos < threeStar) {
							score = 3;
						}
						EndPlay (4); // Success
					} else {
						EndPlay (1); // Stagnant
					}
					// Reset frameCounter
					frameCounter = 0;
				}
			} else {
				frameCounter = 0; // reset frame counter to 0 because avatar speed hasn't reached 0 yet
				if (pastZone) {
					EndPlay (3); // Flew past zipline
				}
				if (floorZone.inFloorZone) {
					EndPlay (2); // Fell off zipline
				}
			}
		}
	}

}
