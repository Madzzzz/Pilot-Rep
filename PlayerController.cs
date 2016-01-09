using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    public Camera viewport;
    CharacterController cc;

    float xSpeed;
    float zSpeed;

    Vector3 moveVector;

    float vVelocity;
    public float gravity = 1F;

	public float forwardSpeed;
	public float jumpHeight;

    void Start () {
        viewport = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();

    }

	void Update () {

        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");

        moveVector = new Vector3(xSpeed, 0, zSpeed);
        moveVector = transform.TransformDirection(moveVector) * forwardSpeed;

        vVelocity += Physics.gravity.y * gravity * Time.deltaTime;

        if (Input.GetKeyDown ("space") && cc.isGrounded) {      // jumping function
            vVelocity = jumpHeight;
        }

        moveVector.y = vVelocity;
        cc.Move(moveVector * Time.deltaTime);
		
    }
}
