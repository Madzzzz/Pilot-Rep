using UnityEngine;
using System.Collections;

public class StayOnPlatForm : MonoBehaviour {

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            coll.GetComponent<PlayerController>().onPlatform = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.GetComponent<PlayerController>().onPlatform = false;

        }
    }
}
