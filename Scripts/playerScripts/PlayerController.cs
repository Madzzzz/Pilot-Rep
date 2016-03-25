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
        GameObject.Find("OldBubbaManager").GetComponent<BubbaManager>().PlaceBubba();
        //Refreranser
        viewport = GetComponentInChildren<Camera>();
        cc = GetComponent<CharacterController>();
        forwardSpeed = forwardSpeedIn;
    }

    public void loadPos(float posX, float posY, float posZ)
    {
        gameObject.transform.position = new Vector3(posX, posY, posZ);
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
    {
        //Faktisk bevegelse
        xSpeed = Input.GetAxis("Horizontal");
        zSpeed = Input.GetAxis("Vertical");
        platformVector = new Vector3(0, 0, 0);

        if (cc.isGrounded)
        {
            moveVector = new Vector3(xSpeed, 0, zSpeed);
            airMoveVector = new Vector3(0, 0, 0);
            moveVector = transform.TransformDirection(moveVector) * forwardSpeed;
            vVelocity = 0; //her settes y-akse fart(hopping, falling) til 0 om CC er på bakken.
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

        if(vVelocity <= -30) //død av gravitasjon
        {
            gameObject.GetComponent<PlayerHealth>().health = 0;
        }

        if(sad == true) //krympekraften til depression og mindre movespeed
        {
            forwardSpeed = forwardSpeedIn/2;
            if (Input.GetKey("q"))
                if (gameObject.transform.localScale.y < 1.0f)
                {
                    gameObject.transform.localScale += new Vector3(0.00f, 0.01f, 0.00f);
                    //Camera.main.transform.localScale -= new Vector3(0.00f, 0.005f, 0.00f);
                }

            if (Input.GetMouseButton(2))
                if (gameObject.transform.localScale.y > 0.3f)
                {
                    gameObject.transform.localScale -= new Vector3(0.00f, 0.01f, 0.00f);
                    //Camera.main.transform.localScale += new Vector3(0.00f, 0.005f, 0.00f);
                }
        }

        if (sad == false)
        {
            if (gameObject.transform.localScale.y < 1.0f)
            {
                gameObject.transform.localScale += new Vector3(0.00f, 0.01f, 0.00f);
                //Camera.main.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            }
        }

        if (fear == true)
        {
            forwardSpeed = forwardSpeedIn * 2;
        }

        if (fear == false && sad == false)
        {
            forwardSpeed = forwardSpeedIn;
        }

        vVelocity += Physics.gravity.y * gravity * Time.deltaTime; // om vVel ikke blir satt til null bare øker den hver gang man faller, dette påvirker hvor fort man faller, dør av gravitasjon og kasting/dropping.
        moveVector.y = vVelocity;                                                   //gravitasjons-variabel
        allMoveVector = (moveVector + platformVector + airMoveVector);              
        cc.Move(allMoveVector * Time.deltaTime);                                    //beveg karakteren med variablene
    }
}