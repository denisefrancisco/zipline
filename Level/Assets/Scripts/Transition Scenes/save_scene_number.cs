using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class save_scene_number : MonoBehaviour {

	//this int is for the loading level, to decide which level to loading after the loading page
	//***IMPORTANT**, when you want to call a level, please start indexing AT ZERO!!! (0)
	public string[] levelList;
	public string level;

	// Use this for initialization
	void Start () {
		foreach (string x in levelList) {
			Debug.Log (x);
		}
		if (GameObject.FindGameObjectsWithTag ("Level").Length > 1) {
			foreach (GameObject x in GameObject.FindGameObjectsWithTag("Level")) {
				if (x.transform.position.z == 500 && SceneManager.GetActiveScene().name == "map_level") {
					Destroy (x);
				}
			}
		}
		DontDestroyOnLoad (gameObject);
		levelList = new string[6];
		levelList [0] = "LabLevel1";
		levelList [1] = "LabLevel2";
		levelList [2] = "LabLevel3";
		levelList [3] = "LabLevel4";
		levelList [4] = "LivingRoomLevel5";
		levelList [5] = "LivingRoomLevel6";
	}

	public void LoadLevelNum(int num) {
		level = levelList [num];
		Debug.Log ("THIS IS THE LEVEL");
		Debug.Log (level);
	}

	public void destroySceneLoader() {
		Destroy (GameObject.FindGameObjectWithTag ("Level"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
