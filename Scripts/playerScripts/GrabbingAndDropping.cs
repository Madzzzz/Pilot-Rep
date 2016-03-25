using UnityEngine;
using System.Collections;

public class GrabbingAndDropping : MonoBehaviour {

    //plukke opp og slippe/kaste ting

	GameObject grabbedObject;
    public float throwForce;
    Vector3 previousGrabPosition;
    public float dropForce;
    Vector3 dropVelocity;
    public bool rage = false;

    GameObject GetHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
		
		return null;
	}
    void tryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !canGrab(grabObject))
            return;

        else
        {
            grabbedObject = grabObject;
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
            grabbedObject.AddComponent<Grabbed>();
            gameObject.GetComponentInChildren<Hue>().Grabbing();

        }
    }

	bool canGrab(GameObject candidate)
    {
        if (candidate.GetComponent<Renderer>() != null)
        {
            if (candidate.GetComponent<Renderer>().bounds.size.magnitude < 2)
                return candidate.GetComponent<Rigidbody>() != null;

            else
                return false;
        }

        else
            return false;
	}

	public void dropObject()
    {
		if (grabbedObject == null)
			return;

       if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 dropVector = grabbedObject.transform.position - previousGrabPosition;
            float speed = (dropVector.magnitude / Time.deltaTime)/4;
            dropVelocity = ((speed/dropForce) * dropVector.normalized) + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().allMoveVector;
            grabbedObject.GetComponent<Rigidbody>().velocity = dropVelocity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        }
        Destroy(grabbedObject.GetComponent<Grabbed>());
        gameObject.GetComponentInChildren<Hue>().Dropping();
        grabbedObject = null;
	}

    void throwObject()
    {
        if (grabbedObject == null)
            return;
        
        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - Camera.main.transform.position;
            Vector3 throwVelocity =  (throwVector.normalized * throwForce) + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().allMoveVector;
            grabbedObject.GetComponent<Rigidbody>().velocity = throwVelocity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        }
        Destroy(grabbedObject.GetComponent<Grabbed>());
        gameObject.GetComponentInChildren<Hue>().Dropping();
        grabbedObject = null;

    }

    public void StartRage()
    {
        rage = true;
    }

    public void StopRage()
    {
        rage = false;
    }

    void Update ()
    {
		
		if (Input.GetKeyDown("e"))
        {
			if (grabbedObject == null)
				tryGrabObject (GetHoverObject (2));

			else
				dropObject ();
		}

        if (Input.GetKeyDown("q"))
        {
            if (rage == true)
                throwObject();
        }

		if (grabbedObject != null)
        {
            previousGrabPosition = grabbedObject.transform.position;
			Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * 1.5f;
			grabbedObject.transform.position = newPosition;
        }
    }
}
