using UnityEngine;
using System.Collections;

public class Depression : MonoBehaviour {

    public bool depressionOn = false;

    void CheckRageRange(float range)
    {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            if (raycastHit.collider.gameObject.tag == ("Depression"))
            {
                raycastHit.collider.gameObject.GetComponent<DepressionObjects>().Transform();
            }
            else
                return;
        }
        else
            return;
    }

    public void StartDepression()
    {
        depressionOn = true;
    }

    public void StopDepression()
    {
        depressionOn = false;
    }

    void Update()
    {
        if (Camera.main.GetComponent<MouseScript>().escapePressed == false && Camera.main.GetComponent<MouseScript>().powerMenu == false)
        {
            if (depressionOn == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CheckRageRange(5);
                }
            }
        }
    }
}
