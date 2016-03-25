using UnityEngine;
using System.Collections;

public class PlatformDetect : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == ("Player"))
        {
            col.GetComponent<PlayerController>().onPlatform = true;
            col.GetComponent<PlayerController>().MovePlat = gameObject.transform.parent.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == ("Player"))
        {
            col.GetComponent<PlayerController>().onPlatform = false;
        }
    }
}
