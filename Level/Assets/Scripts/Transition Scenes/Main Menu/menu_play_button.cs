using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class menu_play_button : MonoBehaviour {

	public void selectPage() {
		SceneManager.LoadScene ("select_menu");
	}
		

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
