using UnityEngine;
using System.Collections;

public class MenuModal : MonoBehaviour {

	private GameObject menuModal;	// modal GO reference

	// Make the Menu Modal appear
	public void ActivateMenuModal () {
		menuModal.SetActive(true);
	}

	// Make the Menu Modal disappear
	public void DeactivateMenuModal () {
		menuModal.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		// Find the menu modal GO and initially deactivate it
		menuModal = GameObject.Find("MenuModal");
		Debug.Log (menuModal.name);
		menuModal.SetActive(false);
	}
}
