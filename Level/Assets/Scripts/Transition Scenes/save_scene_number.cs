using UnityEngine;
using System.Collections;

public class save_scene_number : MonoBehaviour {

	//this int is for the loading level, to decide which level to loading after the loading page
	//***IMPORTANT**, when you want to call a level, please start indexing AT ZERO!!! (0)
	public string[] levelList;
	public int levelNum;
	public string level;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		levelList = new string[6];
		levelList [0] = "LabLevel1";
		levelList [1] = "LabLevel2";
		levelList [2] = "LabLevel3";
		levelList [3] = "LabLevel4";
		levelList [4] = "LivingRoomLevel5";
		levelList [5] = "Level1AnthonyScene";
	}

	public void LoadLevelNum(int num) {
		level = levelList [num];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
