using UnityEngine;
using System.Collections;

public class ButtonInteract : MonoBehaviour {


    void TryInteract(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            if (raycastHit.collider.gameObject.name == ("TrapOpener"))
            {
                raycastHit.collider.gameObject.GetComponent<TrapButton1>().TrapOpen();
            }
            else
                return;
        }
        else
            return;
    }

    void Update ()
    {
        if (Input.GetKeyDown("e"))
        {
            TryInteract(2);
        }
	}
}
