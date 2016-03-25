using UnityEngine;
using System.Collections;

public class PlaceholderWinWall : MonoBehaviour {

    public Transform winWall;
    public Transform winTrapPos;
    public float doorSpeed;

    public bool winButtonPressed = false;

    Vector3 direction;
    Transform destination;

    void Start()
    {
        SetDestination(winTrapPos);
    }

    public void moveTheWall()
    {
        winButtonPressed = true;
    }

    void FixedUpdate()
    {

        if (winButtonPressed == true)
        {
            SetDestination(winTrapPos);
            winWall.GetComponent<Rigidbody>().MovePosition(winWall.position + direction * doorSpeed * Time.fixedDeltaTime);
        }

        if (Vector3.Distance(winWall.position, destination.position) < doorSpeed * Time.fixedDeltaTime)
        {
            doorSpeed = 0;
        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(winTrapPos.position, winWall.localScale);

    }

    void SetDestination(Transform dest)
    {

        destination = dest;
        direction = (destination.position - winWall.position).normalized;

    }
}
