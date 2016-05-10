using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class animOnButton : MonoBehaviour {

	/*Variable 'go' will be used later as a force added to the rb to propel 
			*him in x position animation.
		*The 'movement_sp' float is used as a reference to speed. If the animation
			*is moving too slowly increase this variable.
		*The first Collider named 'feet' is the name of the box collider that 
			*must be on the avatar.
		*The next Collider named origin is the collider that the avatar
			*begins on before zip lining.
			*
			*When screen size is 271 Movement is 2.05, when the size is 5, adjust to .5f.
			*Also, if not moving, check gravity and mass before touching this script. 
			*	Then movement speed.
		*/

	private GameObject avatar;
	private SpriteRenderer sprite; // avatar's sprite
	private Animator anim;
	private bool go = false;
	private float movement_sp = 1.75f;
	/* Flag indicating direction avatar is facing; must be public
	 * so flag can be reset to true when level is reset */
	public bool facingRight; 
	private float direction; // horizontal direction of avatar's movement

	private Collider2D feet;
	public Collider2D origin;
	private Rigidbody2D rb;
	private Collider2D trolley;
	private float quarter = .25f;

// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		trolley = avatar.GetComponent<EdgeCollider2D> ();
		anim = avatar.GetComponent<Animator> ();
		feet = avatar.GetComponent<BoxCollider2D> ();
		rb = avatar.GetComponent<Rigidbody2D> ();
		sprite = avatar.GetComponent<SpriteRenderer> ();
		facingRight = true;
	}

	//Use this for what happens when the button is clicked.
	public void OnClick() {
		if (gameObject.activeSelf == true) {
			// Apply Unity physics to avatar rigidbody
			rb.isKinematic = false;

			//There is a trigger called "onClick" in the animator's parameters. 
			anim.SetTrigger ("onClick");
			go = true;
		}
	}

	//Update is called once per frame.
	void FixedUpdate () {
		float direction = rb.velocity.x;
		if ((direction > 1) && !facingRight) {
			sprite.flipX = false;
			facingRight = !facingRight;
		} else if ((direction < -1) && facingRight) {
			sprite.flipX = true;
			facingRight = !facingRight;
		}

		if (go) {
			/* The 'if' statement checks to see if the player is currently on the piece of furniture.
			*  if he is, he will keep moving forward, if not he will recieve a force to
			*  push him on the zip line initially.*/
			string sceneName = SceneManager.GetActiveScene ().name;
			if ((sceneName == "LabLevel1") | (sceneName == "LabLevel2") | (sceneName == "LabLevel3") | (sceneName == "LabLevel4")) {
				movement_sp = 1f;
			}
			if ((sceneName == "LivingRoomLevel5") | (sceneName == "LivingRoomLevel6")){
				movement_sp = 1.6f;
			}
			if (feet.IsTouching (origin)) { 	
				Debug.Log("pushingforward");
				rb.AddForce (Vector3.right * movement_sp, ForceMode2D.Impulse);
			}
		}
	}
}