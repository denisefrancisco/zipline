using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Script of public functions that load various scenes
public class SceneTransition : MonoBehaviour {

	// Load main menu scene
	public void MainMenu() {
		SceneManager.LoadScene ("start_menu");
	}

	// Load select menu scene
	public void SelectMenu() {
		SceneManager.LoadScene ("select_menu");
	}

	// TODO: load help scene

	// Load options menu scene
	public void OptionsMenu() {
		SceneManager.LoadScene ("options_menu");
	}

	// Load first avatar customization scene
	public void ChooseGender() {
		SceneManager.LoadScene ("zipline_choose_gender");
	}

	// Load level select (map) scene
	public void MapMenu() {
		SceneManager.LoadScene ("map_level");
	}

	// Load living room scene
	public void LivingRoom() {
		SceneManager.LoadScene ("Level1AnthonyScene");
	}

	// TODO: load lab scene

	// Quit game
	public void quitGame() {
		Application.Quit();
	}
}
