using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene ("Level");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
