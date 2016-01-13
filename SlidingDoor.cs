using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {

	public Transform trapWallPlaceholder;
	public Transform endTrapPos;
    public Transform startTrapPos;
    public float doorSpeed;

	public bool trapped = false;

	Vector3 direction;
	Transform destination;

	void Start(){
		SetDestination (endTrapPos);
	}

	public void MakeTrue(){
		trapped = true;
	}

	void FixedUpdate(){

		if (trapped == true) {
            SetDestination(endTrapPos);
			trapWallPlaceholder.GetComponent<Rigidbody>().MovePosition (trapWallPlaceholder.position + direction * doorSpeed * Time.fixedDeltaTime);
		}

		if (Vector3.Distance (trapWallPlaceholder.position, destination.position) < doorSpeed * Time.fixedDeltaTime) {
			doorSpeed = 0;
		}
	}

	void OnDrawGizmos(){

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (endTrapPos.position, trapWallPlaceholder.localScale);

	}

	void SetDestination(Transform dest){

		destination = dest;
		direction = (destination.position - trapWallPlaceholder.position).normalized;

	}
}
