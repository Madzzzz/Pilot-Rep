using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera viewport;
    CharacterController cc;

    float xSpeed;
    float zSpeed;
    public bool onPlatform = false;
    public bool onBouncypad = false;
    float bounceHeight = 10;

    Vector3 moveVector;
    Vector3 platformVector;

    float vVelocity;
    public float gravity = 1F;

	public float forwardSpeed;
	public float jumpHeight;
    GameObject MovePlat;

    void Start ()
    {
        viewport = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == ("MovingPlatform"))
        {
            onPlatform = true;
            MovePlat = coll.gameObject.transform.parent.gameObject;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == ("MovingPlatform"))
            onPlatform = false;
    }

    void FixedUpdate ()
    {
        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");

        moveVector = new Vector3(xSpeed, 0, zSpeed);
        platformVector = new Vector3(0, 0, 0);
        moveVector = transform.TransformDirection(moveVector) * forwardSpeed;

        if (cc.isGrounded)
        {
            vVelocity = 0;
            if (Input.GetKeyDown("space"))
                vVelocity = jumpHeight;
        }

        if (onBouncypad == true)
        {
            vVelocity = bounceHeight;
            onBouncypad = false;
        }

        if (onPlatform == true)
        {
            platformVector = (MovePlat.GetComponent<MovingPlatform>().direction);
        }
        
        vVelocity += Physics.gravity.y * gravity * Time.deltaTime;
        moveVector.y = vVelocity;
        cc.Move((moveVector + platformVector) * Time.deltaTime);
    }
}
