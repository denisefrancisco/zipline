using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

//	public GameObject loadScene;
	private AsyncOperation load;
	private save_scene_number loadingPage;

	void Start() {
		loadingPage = GameObject.FindGameObjectWithTag ("Level").GetComponent<save_scene_number>();
		Debug.Log(loadingPage.level);
		load = SceneManager.LoadSceneAsync (loadingPage.level);
		load.allowSceneActivation = false;
		GameObject.FindGameObjectWithTag ("Level").transform.position = new Vector3 (0,0,500);
	}

	IEnumerator wait() {
		yield return new WaitForSeconds (3);
		load.allowSceneActivation = true;
	}

	void Update() {
		Debug.Log (load.progress);
		if (load.progress == 0.9f && load.allowSceneActivation == false) {
			StartCoroutine (wait ());		
		}
	}
		
//	public void LoadSceneNum(int num) {
//		if (num < 0 || num >= SceneManager.sceneCountInBuildSettings){
//			Debug.LogWarning("Can't load scene num " + num + ", SceneManager only has" + SceneManager.sceneCountInBuildSettings + "scenes in Build Seetings!");
//			return;
//		}
//		LoadingScreenManager.LoadScene (num);
//
//	}
}