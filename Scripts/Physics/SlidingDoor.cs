using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {

	public Transform trapWallPlaceholder;
	public Transform endTrapPos;
    public Transform startTrapPos;
    public float doorSpeed;

	Vector3 direction;
	Transform destination;

	void Start(){
		SetDestination (startTrapPos);
	}

	public void MakeTrue(){
        SetDestination(endTrapPos);
        doorSpeed = 2;
    }

	void FixedUpdate(){

		trapWallPlaceholder.GetComponent<Rigidbody>().MovePosition (trapWallPlaceholder.position + direction * doorSpeed * Time.fixedDeltaTime);


        if (Vector3.Distance(trapWallPlaceholder.position, destination.position) < doorSpeed * Time.fixedDeltaTime)
        {
            doorSpeed = 0;
        }
	}

	void OnDrawGizmos(){

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (endTrapPos.position, trapWallPlaceholder.localScale);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTrapPos.position, trapWallPlaceholder.localScale);

    }

	void SetDestination(Transform dest){

		destination = dest;
		direction = (destination.position - trapWallPlaceholder.position).normalized;

	}

    public void Triggerd()
    {
        SetDestination(startTrapPos);
        doorSpeed = 2;
    }
}
