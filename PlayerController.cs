using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Variabler
    public Camera viewport;
    CharacterController cc;

    float xSpeed;
    float zSpeed;
    public bool onPlatform = false;
    public bool onBouncypad = false;
    public bool tookDamage = false;

    Vector3 moveVector;
    Vector3 airMoveVector;
    Vector3 platformVector;
    public Vector3 allMoveVector;

    public float vVelocity;
    public float gravity = 1F;
    bool sad = false;
    bool fear = false;

	public float forwardSpeedIn;
    float forwardSpeed;
	public float jumpHeight;
    public GameObject MovePlat;

    void Start ()
    {
        //Refreranser
        viewport = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
        forwardSpeed = forwardSpeedIn;
    }

    public void SadPower() //Om depression er aktivert
    {
        sad = true;
    }

    public void NotSadAnyMore()
    {
        sad = false;
    }

    public void FearPower()
    {
        fear = true;
    }

    public void NoFear()
    {
        fear = false;
    }

    void FixedUpdate ()
    {   //Faktisk bevegelse
        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");
        platformVector = new Vector3(0, 0, 0);

        if (cc.isGrounded)
        {
            moveVector = new Vector3(xSpeed, 0, zSpeed);
            airMoveVector = new Vector3(0, 0, 0);
            moveVector = transform.TransformDirection(moveVector) * forwardSpeed;
            vVelocity = 0;
            if (Input.GetKey(KeyCode.Space)) //hopping
                vVelocity = jumpHeight;
        }

        if (cc.isGrounded == false)
        {
            airMoveVector = new Vector3(xSpeed, 0, zSpeed);
            airMoveVector = transform.TransformDirection(airMoveVector) * (forwardSpeed/4);
        }

        if (onPlatform == true)
        {
            platformVector = (MovePlat.GetComponent<MovingPlatform>().direction); //platformbevegelsen, kunne kansje vært mer effektiv
        }

        if(tookDamage == true)
        {
            vVelocity = 6;
            tookDamage = false;
        }

        if(vVelocity <= -30) //død av gravitasjon
        {
            gameObject.GetComponent<PlayerHealth>().health = 0;
        }

        if(sad == true) //krympekraften til depression og mindre movespeed
        {
            forwardSpeed = forwardSpeedIn/2;
            if (Input.GetMouseButton(0))
                if (gameObject.transform.localScale.x < 1.0f)
                    gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

            if (Input.GetMouseButton(2))
                if (gameObject.transform.localScale.x > 0.3f)
                    gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }

        if (sad == false)
        {
            if (gameObject.transform.localScale.x < 1.0f)
                gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }

        if (fear == true)
        {
            forwardSpeed = forwardSpeedIn * 2;
        }

        if (fear == false && sad == false)
        {
            forwardSpeed = forwardSpeedIn;
        }

        vVelocity += Physics.gravity.y * gravity * Time.deltaTime;                  //gravitasjons-matte
        moveVector.y = vVelocity;                                                   //gravitasjons-variabel
        allMoveVector = (moveVector + platformVector + airMoveVector);              
        cc.Move(allMoveVector * Time.deltaTime);                                    //beveg karakteren med variablene
    }
}