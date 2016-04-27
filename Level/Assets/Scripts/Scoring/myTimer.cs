using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Very Important!! //

public class myTimer : MonoBehaviour {

	public float myCoolTimer = 0;
	private Text timerText;


	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		myCoolTimer += Time.deltaTime;
		timerText.text = myCoolTimer.ToString ("f2");
	}
}
