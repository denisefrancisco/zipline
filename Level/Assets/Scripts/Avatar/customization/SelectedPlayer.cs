using UnityEngine;
using System.Collections;

public class SelectedPlayer : MonoBehaviour {

	private left_button_customize left_button;
	private right_button_customize right_button;
	public string chosen_outfit;
	public GameObject avatar;

	void Awake() {
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		left_button = avatar.GetComponent<left_button_customize>();


	}

	// Update is called once per frame
	void Update () {
		chosen_outfit = left_button.chosen_clothing;
		Debug.Log(chosen_outfit);

	}
}