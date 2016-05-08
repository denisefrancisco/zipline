using UnityEngine;
using System.Collections;

public class doubleTapAnimate : MonoBehaviour {
	#if UNITY_STANDALONE_OSX
	public Transform buttonClick;
	public GameObject drawLine;
	public GameObject tutorialText;

	void Awake(){
		StartCoroutine("SetGuard");
	}

	// Use this for initialization
	void Start () {
		drawLine = GameObject.Find ("Quad");
	}

	IEnumerator SetGuard() {
		while (true)
		{
			yield return new WaitForSeconds (1);
			drawLine.SetActive (true);
			yield return new WaitForSeconds (1);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
			yield return new WaitForSeconds (0.2f);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,5);
			yield return new WaitForSeconds (0.2f);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,-5);
			yield return new WaitForSeconds (0.2f);
			buttonClick.position = new Vector3(buttonClick.position.x,buttonClick.position.y,5);
			drawLine.SetActive (false);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) == true) {
			gameObject.SetActive (false);
			drawLine.SetActive (false);
			tutorialText.SetActive(false);
		}

	}


	#endif
}

