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
        //gameObject.transform.Translate(Vector3.forward / 5);
    }

    public void Dropping()
    {
        //gameObject.transform.Translate(Vector3.back / 5);
    }

    void FixedUpdate()
    {
        if(cc.isGrounded == true)
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
                gameObject.GetComponent<Animation>().Play("walkin");
        if (cc.isGrounded == true)
            if (Input.GetKey("space"))
                gameObject.GetComponent<Animation>().Play("jump");

        if (Input.GetKey("e"))
            gameObject.GetComponent<Animation>().Play("holdin");
    }
}
