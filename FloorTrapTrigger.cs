using UnityEngine;
using System.Collections;

public class FloorTrapTrigger : MonoBehaviour {

	//bool trapped = false;

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {
			Debug.Log ("nigga nigga nigga nigga");
		}


		//trapped = true;

		//SlidingDoor.MakeTrue ();

	}
}
