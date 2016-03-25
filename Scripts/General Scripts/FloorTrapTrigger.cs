using UnityEngine;
using System.Collections;

public class FloorTrapTrigger : MonoBehaviour {
    

    void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {
            GameObject.Find("TrapSlide").GetComponent<SlidingDoor>().MakeTrue();
        }
    }
}
