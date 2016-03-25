using UnityEngine;
using System.Collections;

public class PatientCamera : MonoBehaviour {

    public Transform cameraMainPos;
    public Transform patient1Transform;
    public Transform patient2Transform;
    public Transform patient3Transform;
    public Transform patient4Transform;
    public Transform cameraObject;

    public float cameraSpeedIn;
    float cameraSpeed;
    float cameraNoSpeed = 0;

    public Vector3 direction;
    public Transform destination;

    void Start()
    {
        ReturnPos();
    }

    public void PatientOne()
    {
        SetDestination(patient1Transform);
    }

    public void PatientTwo()
    {
        SetDestination(patient2Transform);
    }

    public void PatientThree()
    {
        SetDestination(patient3Transform);
    }

    public void PatientFour()
    {
        SetDestination(patient4Transform);
    }

    public void ReturnPos()
    {
        SetDestination(cameraMainPos);
    }

    void SetDestination(Transform dest)
    {
        cameraSpeed = cameraSpeedIn;
        destination = dest;
        direction = (destination.position - cameraObject.position).normalized;

    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(cameraMainPos.position, cameraObject.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(patient1Transform.position, cameraObject.localScale);

        Gizmos.DrawWireCube(patient2Transform.position, cameraObject.localScale);

        Gizmos.DrawWireCube(patient3Transform.position, cameraObject.localScale);

        Gizmos.DrawWireCube(patient4Transform.position, cameraObject.localScale);

    }

    void FixedUpdate()
    {
        cameraObject.GetComponent<Rigidbody>().MovePosition(cameraObject.position + direction * cameraSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(cameraObject.position, destination.position) < cameraSpeed * Time.fixedDeltaTime)
        {
            cameraSpeed = cameraNoSpeed;
        }

    }
}
