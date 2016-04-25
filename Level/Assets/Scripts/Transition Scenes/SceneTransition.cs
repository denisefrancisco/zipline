using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Script of public functions that load various scenes
public class SceneTransition : MonoBehaviour {

	/* Name of scene that requested the options menu
	 * to be loaded, so that the options menu back button can
	 * take the player back to that previous scene */
	private string previousScene;
	private string saved;

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
		//previousScene = SceneManager.GetActiveScene().name;
		//saved = previousScene;
		SceneManager.LoadScene ("options_menu");
	}

	//function for loading last scene before options was clicked, doesn't work
	/*public void OptionsBack() {
		if (previousScene == "start_menu") {
			MainMenu();
		} else if (previousScene == "Level1AnthonyScene") {
			LivingRoom();
		} else {
			Debug.Log("can't go back, previous scene was not registered");
		}
	}*/

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
