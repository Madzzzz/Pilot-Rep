using UnityEngine;
using System.Collections;

public class EcstacyObjects : MonoBehaviour {

    public bool ecstacyOnObject = false;
    
	void Update () {

        if (ecstacyOnObject == true)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            if (gameObject.transform.position.y > 6)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down);
            }

            if (gameObject.transform.position.y < 6)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up);
            }
        }
        

        if (ecstacyOnObject == false)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
