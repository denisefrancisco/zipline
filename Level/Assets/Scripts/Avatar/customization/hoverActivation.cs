using UnityEngine;
using System.Collections;

public class hoverActivation : MonoBehaviour {

	private GameObject girl;
	private GameObject boy;

	// Use this for initialization
	void Start () {
		girl = GameObject.Find("female");
		boy = GameObject.Find("male");
		if(SystemInfo.deviceModel.Contains("iPad")){
			girl.GetComponent<Animator>().enabled = false;
			boy.GetComponent<Animator>().enabled = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
