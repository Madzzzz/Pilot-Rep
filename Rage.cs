using UnityEngine;
using System.Collections;

public class Rage : MonoBehaviour {
    
    public bool rageOn = false;

    void CheckRageRange(float range)
    {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            if (raycastHit.collider.gameObject.tag == ("Rage"))
            {
                raycastHit.collider.gameObject.GetComponent<RageObjects>().RageAffect();
            }

            if (raycastHit.collider.gameObject.tag == ("Destroy"))
            {
                Destroy(raycastHit.collider.gameObject);
            }
            else
                return;
        }
        else
            return;
    }

    public void StartRage()
    {
        rageOn = true;
    }

    public void StopRage()
    {
        rageOn = false;
    }

    void Update()
    {

        if (rageOn == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckRageRange(5);
            }
        }
    }
}
