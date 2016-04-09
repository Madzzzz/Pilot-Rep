using UnityEngine;
using System.Collections;

public class Hue : MonoBehaviour {

    CharacterController cc;

    void Start()
    {
        cc = gameObject.GetComponentInParent<CharacterController>();
    }

    public void HueHue()
    {
        StartCoroutine(Høh());
    }

    IEnumerator Høh()
    {
        gameObject.transform.Translate(Vector3.forward / 6);
        yield return new WaitForSeconds(0.1f);

        gameObject.transform.Translate(Vector3.back / 6);
    }

    public void Grabbing()
    {
        gameObject.GetComponent<Animation>().Play("holdin");
        //gameObject.GetComponent<Animation>().Stop("idle");
    }

    public void Dropping()
    {
        gameObject.GetComponent<Animation>().Stop("holdin");
        //gameObject.GetComponent<Animation>().Play("idle");
    }

    void FixedUpdate()
    {
        if (cc.isGrounded == true && Camera.main.GetComponent<GrabbingAndDropping>().grabbing == false)
        {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
                gameObject.GetComponent<Animation>().Play("walkin");

            if (Input.GetKey("space"))
                gameObject.GetComponent<Animation>().Play("jump");

            //else
                //gameObject.GetComponent<Animation>().Play("idle");
        }
    }
}
