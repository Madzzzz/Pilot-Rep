using UnityEngine;
using System.Collections;

public class GrabbingAndDropping : MonoBehaviour {

	GameObject grabbedObject;
    int throwForce;
    public int regularThrowForce;
    int rageThrowForce;
    Vector3 previousGrabPosition;
    public float dropForce;
    Vector3 dropVelocity;
    public bool rage = false;

    void Start()
    {
        rageThrowForce = regularThrowForce * 3;
    }

    GameObject GetHoverObject(float range) {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
		
		return null;
	}

    void CheckRageRange(float range)
    {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit)) {
            if (raycastHit.collider.gameObject.tag == ("Rage"))
            {
                Destroy(raycastHit.collider.gameObject);
            }
            else
                return;
        }   
            else
                return;
    }

    void tryGrabObject(GameObject grabObject) {

        if (grabObject == null || !canGrab(grabObject))
            return;

        else
        {
            grabbedObject = grabObject;
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;

        }
    }

	bool canGrab(GameObject candidate) {
        if (candidate.GetComponent<Renderer>() != null)
        {
            //Debug.Log(candidate.GetComponent<Renderer>().bounds.size.magnitude);
            if (candidate.GetComponent<Renderer>().bounds.size.magnitude < 7)
                return candidate.GetComponent<Rigidbody>() != null;
            else
                return false;
        }
        else
            return false;
	}

	void dropObject() {
		if (grabbedObject == null)
			return;


       if (grabbedObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - previousGrabPosition;
            float speed = (throwVector.magnitude / Time.deltaTime)/2;
            dropVelocity = (speed/dropForce) * throwVector.normalized;
            grabbedObject.GetComponent<Rigidbody>().velocity = dropVelocity;
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
            if (rage == true)
                throwForce = rageThrowForce;
            else
                throwForce = regularThrowForce;

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
			Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * 1.5f;
			grabbedObject.transform.position = newPosition;
		}

        if (rage == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckRageRange(2);
            }
        }
    }
}
