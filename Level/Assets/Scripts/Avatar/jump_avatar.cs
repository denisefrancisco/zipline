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
	//Update is called once per frame.
	void Update(){
		//grounded below uses a transformer (groundCheck) to check if the avatar is in the air or on the ground.
		//if the avatar is in the air, the grounded boolean will return false
		//Thus causing the avatar's animation to go into 'jump'
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidBody.velocity.y);
	}
}