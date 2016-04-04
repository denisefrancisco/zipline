using UnityEngine;
using System.Collections;

/*This script should only be enabled if the Erase Button
 * has been clicked to enable the player's ability to
 * erase line objects to which this script is attached
 * (attachment occurs in DrawPhysicsLine script where the
 * line GOs are initially created) */
public class ErasePhysicsLine : MonoBehaviour {

	//when line GO is clicked during Erase Mode, delete the line
	void OnMouseDown () {
		Debug.Log ("we've clicked on line object ");
		//Destroy (gameObject);
		Debug.Log ("we've destroyed the line object");
	}

	void Start () {
		Debug.Log ("we're inside the erasephysicsline script");
	}

}
