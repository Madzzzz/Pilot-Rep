using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

        void OnTriggerStay(Collider col)
    {
        if(col.tag == ("Player"))
        {
            col.gameObject.transform.Translate(Vector3.up / 100); //translaterer den slik at den er over bakken
            col.GetComponent<PlayerController>().vVelocity = 10; //også får den farten oppover, se PlayerController for hvorfor.
        }

        else
            col.GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
    }
}
