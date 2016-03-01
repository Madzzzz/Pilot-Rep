using UnityEngine;
using System.Collections;

public class Fear : MonoBehaviour {

    public bool fearOn = false;

    void CheckRageRange(float range)
    {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {

            if (raycastHit.collider.gameObject.tag == ("FearShrink"))
            {
                raycastHit.collider.gameObject.GetComponent<FearObjects>().FearAffect();
            }
            else
                return;
        }
        else
            return;
    }

    public void StartFear()
    {
        fearOn = true;
    }

    public void StopFear()
    {
        fearOn = false;
    }

    void Update()
    {
        if (Camera.main.GetComponent<MouseScript>().escapePressed == false && Camera.main.GetComponent<MouseScript>().powerMenu == false)
        {

            if (fearOn == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CheckRageRange(5);
                }
            }
        }
    }
}
