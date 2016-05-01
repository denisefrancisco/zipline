using UnityEngine;
using System.Collections;

public class start_camera : MonoBehaviour {


	//the list of gameobjects below represent the different combinations of outfits that are available to the player.
	public GameObject brownBoy;
	public GameObject blueBoy;
	public GameObject lightBlueBoy;
	public GameObject girl_pink;
	public GameObject girl_white;
	public GameObject girl_blue;
	public Camera camera;
	//get avatar's initial position for resetting
	private GameObject avatar;
	private GameObject avatar1;
	//this variable is to indicate where the camera initializes to when the game is started
	private Vector3 resetCameraPosition;
	//set avatar's initial position to a variable
	private Vector3 avatarPos;
	private Quaternion avatarRot;
	//this saved_data variable represents the saved information regarding the player's outfit choice
	private GameObject saved_data;
	//the next 3 variables are part of the saved_data Gameobject and therefore have to be saved as well. 
	private GameObject big_boy;
	private GameObject big_girl;
	private SelectedPlayer clothing;

	public void returnCamera(){
		camera.orthographicSize = 5.5f;
		//return the camera to the top of the screen after restarting level
		camera.transform.position = resetCameraPosition;
	}

	public void respawnAvatar() {
		avatar = (GameObject) Instantiate(avatar,avatarPos,avatarRot);
		Destroy (avatar);

	}

	public void respawnAvatarForButton(){
//		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		avatar = (GameObject) Instantiate(avatar,avatarPos,avatarRot);
		Destroy (avatar);
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		avatar.transform.position = avatarPos;
//		avatar.transform.rotation = avatarRot;
	}

	//use this before initialization
	void Awake() {
		//saving the starting position for the camera 
		resetCameraPosition = gameObject.transform.position;
		camera.orthographicSize = 5.5f;
		//find the game object with the saved data
		saved_data = GameObject.Find("Saved Data");
		big_boy = GameObject.Find ("Boy");
		big_girl = GameObject.Find ("girl");
		//these conditions are determined by whether or not a player has gone through character select, or level select.
		//if straight to level select, there is a default avatar. If character select, the chosen avatar will pop up.
		if (big_boy == null && big_girl == null) {
			blueBoy.SetActive (true);
			avatar = blueBoy;
		} else if (big_boy == null) {
			big_girl.transform.position = new Vector3 (0, 0, 1000);
		} else {
			big_boy.transform.position = new Vector3 (0, 0, 1000);
		}
		clothing = saved_data.GetComponent<SelectedPlayer> ();
		if (clothing.chosen_outfit == "blue") {
			blueBoy.SetActive (true);
			avatar = blueBoy;
		} else if (clothing.chosen_outfit == "lightBlue") {
			Debug.Log("we are light blue!");
			lightBlueBoy.SetActive (true);
			avatar = lightBlueBoy;
		} else if (clothing.chosen_outfit == "girl_pink") {
			girl_pink.SetActive (true);
			avatar = girl_pink;
		} else if (clothing.chosen_outfit == "girl_white") {
			girl_white.SetActive (true);
			avatar = girl_white;
		} else if (clothing.chosen_outfit == "girl_blue") {
			girl_blue.SetActive (true);
			avatar = girl_blue;
		} else if (clothing.chosen_outfit == "brown") {
			brownBoy.SetActive (true);
			avatar = brownBoy;
		}
		Debug.Log (avatar.name);

	}
	// Use this for initialization
	void Start () {
		avatar = GameObject.FindGameObjectWithTag ("Avatar");
		avatarPos = avatar.transform.position;
		avatarRot = avatar.transform.rotation;

	}


	
	// Update is called once per frame
	void Update () {

	
	}
}
