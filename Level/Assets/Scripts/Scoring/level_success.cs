using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//this file is for everything that happens during a successful level completion
public class level_success : MonoBehaviour {

	public GameObject playCamera; 	// play camera GO
	//this file is for everything that happens during a successful level completion
	private GameObject avatar;
	//the success popup
	public GameObject success_modal;
	//the confetti prefab that is instantiated when the win function is active
	public GameObject confetti;
	//edge collider of the ziplining avatar
	private EdgeCollider2D ec;
	//the box collider of the current success door
	private BoxCollider2D bc;
	//get rigid body of the avatar
	private Rigidbody2D rb;
	// Reference to timer GO script component
	private myTimer timerScript;	
	//these offsets are for the placement of the confetti prefab so that it fills up the screen
	private bool succeeded;	// Flag indicating player has succeeded
	private Vector3 offset;
	private Vector3 offset1;
	private GameObject confetti1;
	private GameObject confetti2;

	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		rb = avatar.GetComponent<Rigidbody2D> ();
		bc = gameObject.GetComponent<BoxCollider2D> ();
		ec = avatar.GetComponent<EdgeCollider2D> ();
		succeeded = false;
		offset = new Vector3(-1,4,0);
		offset1 = new Vector3(1,4,0);
	}

	IEnumerator wait(){
		timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<myTimer>();
		timerScript.StopTimer ();
		yield return new WaitForSeconds (1);
		success_modal.SetActive(true);	// Activate success modal
		timerScript.StopTimerWon();	// Stop timer and record time to calculate score


		//instantiate confetti!
		confetti1 = (GameObject) Instantiate (confetti, success_modal.transform.position+offset, success_modal.transform.rotation);
		confetti2 = (GameObject) Instantiate (confetti, success_modal.transform.position+offset1,success_modal.transform.rotation);
		StopAllCoroutines();
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Reset failed state when success modal is disabled
		if (!playCamera.activeSelf && succeeded) {
			succeeded = false;
		}

		//if the box collider comes into contact with the avatar's edge collider...
		if (bc.IsTouching(ec) && !succeeded) {
			Debug.Log ("success!");
			succeeded = true; // Flag true (so we only do these functions once)

			//Set rigid body to isKinematic to freeze avatar movement
			rb.isKinematic = true;
			avatar.SetActive(false);	// Deactivate avatar
			StartCoroutine(wait());

		}
	}

	public void deleteConfetti() {
		Destroy (confetti1);
		Destroy (confetti2);
	}
}
