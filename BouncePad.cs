using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<PlayerController>().onBouncypad = true;
        }
    }
}
