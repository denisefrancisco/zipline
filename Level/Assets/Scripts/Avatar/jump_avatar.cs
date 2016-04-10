using UnityEngine;
using System.Collections;

public class jump_avatar : MonoBehaviour {

	private Animator anim;
	public Transform groundCheck;
	public Rigidbody2D rigidBody;
	public bool isJumping;
	public float jumpForce = 2.0f;

	bool grounded = false;
	float groundRadius = .2f;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();    
	}
	void FixedUpdate(){
		//grounded below uses a transformer (groundCheck) to check if the avatar is in the air or on the ground.
		//if the avatar is in the air, the grounded boolean will return false
		//Thus causing the avatar's animation to go into 'jump'
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidBody.velocity.y);
	}
	// Update is called once per frame
	void Update () 
	{
		//this next line assumes 
		if (grounded && Input.GetKeyDown(KeyCode.Space)) 
		{
			// if we aren't already jumping, perform these actions. Do this in this 
			// block because the user is likely to hold down the space key for more than 
			// a single frame. This way if the user is already pressing space (which is where
			// you are setting isJumping to true, this code block will not be executed again
			if (!isJumping )
			{
				isJumping = true;
				rigidBody.AddForce (new Vector2(0, jumpForce));
				anim.SetBool ("isJumping", true);                
			}

		} 
		else if (Input.GetKeyUp(KeyCode.Space)) 
		{
			// remember this runs ever frame so ever frame that the
			// key is up, this code would run. The only time you really
			// want this to happen is if the person was jumping
			if ( isJumping )
			{
				// you want to put this here since the entire action of pressing the space
				// bar completes the jumping. Otherwise you will keep
				//rigidBody.AddForce (Vector2.up * jumpSum);

				// this will stop the behavior so that when this Update method
				// is reentered, the player will no longer be jumping although the key is up
				anim.SetBool ("isJumping", false);
				isJumping = false;                
			}

		}
	}
}
