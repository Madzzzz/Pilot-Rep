using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera viewport;
    CharacterController cc;

    float xSpeed;
    float zSpeed;
    bool moveTrue;
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

    void Start () {
        moveTrue = true;
        viewport = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
        MovePlat = GameObject.Find("MovingPlatform");

    }

	void FixedUpdate () {

        if (moveTrue == true)
        {

            xSpeed = Input.GetAxis("Horizontal");
            zSpeed = Input.GetAxis("Vertical");

            moveVector = new Vector3(xSpeed, 0, zSpeed);
            platformVector = new Vector3(0, 0, 0);
            moveVector = transform.TransformDirection(moveVector) * forwardSpeed;

            vVelocity += Physics.gravity.y * gravity * Time.deltaTime * Time.maximumDeltaTime;
            if (Input.GetKeyDown("space") && cc.isGrounded)
            {
                vVelocity = jumpHeight;
            }

            if (onBouncypad == true)
            {
                vVelocity = bounceHeight;
                platformVector = (MovePlat.GetComponent<MovingPlatform>().direction);
                onBouncypad = false;
            }

            if (onPlatform == true)
            {
                platformVector = (MovePlat.GetComponent<MovingPlatform>().direction);
            }

            moveVector.y = vVelocity;
            cc.Move((moveVector + platformVector) * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            moveTrue =! moveTrue;
        }


        

    }
}
