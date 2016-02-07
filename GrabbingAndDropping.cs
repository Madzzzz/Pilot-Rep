using UnityEngine;
using System.Collections;

public class GrabbingAndDropping : MonoBehaviour {

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
            grabbedObject.GetComponent<Rigidbody>().detectCollisions = false;

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

	void dropObject()
    {
		if (grabbedObject == null)
			return;

       if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - previousGrabPosition;
            float speed = (throwVector.magnitude / Time.deltaTime)/2;
            dropVelocity = (speed/dropForce) * throwVector.normalized;
            grabbedObject.GetComponent<Rigidbody>().velocity = dropVelocity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().detectCollisions = true;
        }

		grabbedObject = null;
	}

    void throwObject()
    {
        if (grabbedObject == null)
            return;
        
        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - Camera.main.transform.position;
            float speed = throwVector.magnitude / Time.deltaTime;
            Vector3 throwVelocity = speed * throwVector.normalized / 15;
            throwVelocity += Camera.main.transform.forward * throwForce;
            grabbedObject.GetComponent<Rigidbody>().velocity = throwVelocity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().detectCollisions = true;
        }

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
