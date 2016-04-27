using UnityEngine;
using System.Collections;

public class start_camera : MonoBehaviour {

	public GameObject brownBoy;
	public GameObject blueBoy;
	public GameObject lightBlueBoy;
	public Camera camera;
	//get avatar's initial position for resetting
	private GameObject avatar;
	//this variable is to indicate where the camera initializes to when the game is started
	private Vector3 resetCameraPosition;
	//set avatar's initial position to a variable
	private Vector3 avatarPos;
	private Quaternion avatarRot;
	private GameObject saved_data;
	private GameObject big_boy;
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

	// Use this for initialization
	void Start () {
		//saving the starting position for the camera 
		resetCameraPosition = gameObject.transform.position;
		camera.orthographicSize = 5.5f;
		saved_data = GameObject.Find("Saved Data");
		big_boy = GameObject.Find ("Boy");
//		Destroy(big_boy);
		big_boy.transform.position = new Vector3 (0, 0, 1000);
		clothing = saved_data.GetComponent<SelectedPlayer>();
		Debug.Log (clothing.chosen_outfit);
		if (clothing.chosen_outfit == "blue") {
			
			avatar = blueBoy;
			avatar.SetActive (true);
		} else if (clothing.chosen_outfit == "lightBlue") {
			avatar = lightBlueBoy;
			avatar.SetActive (true);
		} else {
			avatar = brownBoy;
			avatar.SetActive (true);
		}
		Debug.Log (avatar.name);
		avatarPos = avatar.transform.position;
		avatarRot = avatar.transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
