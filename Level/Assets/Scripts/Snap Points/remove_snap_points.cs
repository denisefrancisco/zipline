using UnityEngine;
using System.Collections;

public class remove_snap_points : MonoBehaviour {

	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public GameObject point4;
	public GameObject point5;
	public GameObject point6;
	public GameObject point7;
	public GameObject point8;
	public GameObject point9;
	public GameObject point10;
	public GameObject point11;
	public GameObject point12;
	public GameObject point13;
	public GameObject point14;
	public GameObject point15;
	public GameObject point16;
	public GameObject point17;

	public void removeSnapPoints(){
		point1.SetActive(false);
		point2.SetActive(false);
		point3.SetActive(false);
		point4.SetActive(false);
		point5.SetActive(false);
		point6.SetActive(false);
		point7.SetActive(false);
		point8.SetActive(false);
		point9.SetActive(false);
		point10.SetActive(false);
		point11.SetActive(false);
		point12.SetActive(false);
		point13.SetActive(false);
		point14.SetActive(false);
		point15.SetActive(false);
		point16.SetActive(false);
		point17.SetActive(false);

	}

	public void applySnapPoint() {
		point1.SetActive(true);
		point2.SetActive(true);
		point3.SetActive(true);
		point4.SetActive(true);
		point5.SetActive(true);
		point6.SetActive(true);
		point7.SetActive(true);
		point8.SetActive(true);
		point9.SetActive(true);
		point10.SetActive(true);
		point11.SetActive(true);
		point12.SetActive(true);
		point13.SetActive(true);
		point14.SetActive(true);
		point15.SetActive(true);
		point16.SetActive(true);
		point17.SetActive(true);

	}

	// Use this for initialization
	void Start () {
		Debug.Log (point3.transform.position);
	}








	
	// Update is called once per frame
	void Update () {
	
	}
}
