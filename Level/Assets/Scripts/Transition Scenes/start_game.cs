using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour {

	public void MainMenu() {
		SceneManager.LoadScene ("start_menu");
	}

	public void StartGame() {
		SceneManager.LoadScene ("Level1AnthonyScene");
	}

	public void chooseGender() {
		SceneManager.LoadScene ("zipline_choose_gender");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
