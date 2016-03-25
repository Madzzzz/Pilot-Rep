using UnityEngine;
using System.Collections;

public class EcstacyObjects : MonoBehaviour {

    public bool ecstacyOnObject = false;


    public void Glow()
    {
        Behaviour halo = (Behaviour)GetComponent("Halo");

            if (halo.enabled == true)
            {
                halo.enabled = false;
                return;
            }

            if (halo.enabled == false)
            {
                halo.enabled = true;
                return;
            }
        
    }

    void Update () {

        
            if (gameObject.tag == "Ecstacy")
            {

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
}
