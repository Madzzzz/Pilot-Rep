using UnityEngine;
using System.Collections;

public class Ecstacy : MonoBehaviour {
    
    public bool ecstasyOn = false;

    void CheckRageRange(float range)
    {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            if (raycastHit.collider.gameObject.tag == ("Ecstacy"))
            {
                raycastHit.collider.gameObject.GetComponent<EcstacyObjects>().Float();
            }

            if (raycastHit.collider.gameObject.tag == ("Ecstacy_Glow"))
            {
                raycastHit.collider.gameObject.GetComponent<EcstacyObjects>().Glow();
            }
            else
                return;
        }
        else
            return;
    }

    public void StartEcstacy()
    {
        ecstasyOn = true;
    }

    public void StopEcstacy()
    {
        ecstasyOn = false;
    }

    void Update()
    {
        if (Camera.main.GetComponent<MouseScript>().escapePressed == false && Camera.main.GetComponent<MouseScript>().powerMenu == false)
        {

            if (ecstasyOn == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CheckRageRange(5);
                }
            }
        }
    }
}
