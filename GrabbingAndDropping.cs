using UnityEngine;
using System.Collections;

public class GrabbingAndDropping : MonoBehaviour {

	GameObject grabbedObject;
	float grabbedObjectSize;
    public int throwForce;
    Vector3 previousGrabPosition;

	GameObject GetHoverObject(float range) {

		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;
		if (Physics.Linecast (position, target, out raycastHit))
			return raycastHit.collider.gameObject;
		
		return null;
	}

	void tryGrabObject(GameObject grabObject) {

		if (grabObject == null || !canGrab(grabObject))
			return;

		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
        grabbedObject.GetComponent<Rigidbody>().useGravity = false;
    }

	bool canGrab(GameObject candidate) {
		return candidate.GetComponent<Rigidbody> () != null;
	}

	void dropObject() {
		if (grabbedObject == null)
			return;


       if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - previousGrabPosition;
            float speed = throwVector.magnitude / Time.deltaTime;
            Vector3 throwVelocity = speed * throwVector.normalized;
            grabbedObject.GetComponent<Rigidbody>().velocity = throwVelocity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        }

		grabbedObject = null;
	}

    void throwObject()
    {
        if (grabbedObject == null)
            return;


        if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - previousGrabPosition;
            float speed = throwVector.magnitude / Time.deltaTime;
            Vector3 throwVelocity = speed * throwVector.normalized;
            throwVelocity += Camera.main.transform.forward * throwForce;
            grabbedObject.GetComponent<Rigidbody>().velocity = throwVelocity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        }

        grabbedObject = null;

    }

	void Update () {
		
		if (Input.GetKeyDown("e")) {
			
			if (grabbedObject == null)
				tryGrabObject (GetHoverObject (2));
			else
				dropObject ();
		}

        if (Input.GetKeyDown("q")) {

            throwObject();
        }

		if (grabbedObject != null) {
            previousGrabPosition = grabbedObject.transform.position;
			Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
			grabbedObject.transform.position = newPosition;
		}
	}
}
