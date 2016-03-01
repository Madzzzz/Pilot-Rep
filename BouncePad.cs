using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

    void OnTriggerStay(Collider col)
    {
        if(col.tag == ("Player"))
        {
            col.GetComponent<PlayerController>().vVelocity = 10;
        }

        else
            col.GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
    }
}
