using UnityEngine;
using System.Collections;

public class PowerWheel : MonoBehaviour {

    bool escapePressed;
    //Depression depression;

    void Start() {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    void detectWhichPower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "Rage")
            {
                Debug.Log("FEEL THE BERN");
                Camera.main.GetComponent<GrabbingAndDropping>().rage = true;
                //GameObject.FindGameObjectWithTag("Depression").GetComponent<Depression>().depresionOn = false;
            }

            if (hit.transform.name == "Fear")
            {
                Debug.Log("DEUS VULT");
                Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
                //GameObject.FindGameObjectWithTag("Depression").GetComponent<Depression>().depresionOn = false;
            }

            if (hit.transform.name == "Happy")
            {
                Debug.Log("CANT STUMP THE TRUMP");
                Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
                //GameObject.FindGameObjectWithTag("Depression").GetComponent<Depression>().depresionOn = false;
            }

            if (hit.transform.name == "Depression")
            {
                Debug.Log("ME IRL");
                Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
                //depression.GetComponent<Depression>().depresionOn = true;
                //GameObject.FindGameObjectWithTag("Depression").GetComponent<Depression>().depresionOn = true;
            }

            if (hit.transform.name == "Regret")
            {
                Debug.Log("NO REGRATS");
                Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
                //GameObject.FindGameObjectWithTag("Depression").GetComponent<Depression>().depresionOn = false;
            }
        }

        
    }
	
	void Update () {

        escapePressed = Camera.main.GetComponent<MouseScript>().escapePressed;

        if (escapePressed == false)
        {
            if (Input.GetMouseButton(1))
                gameObject.GetComponent<Renderer>().enabled = true;
            else
                gameObject.GetComponent<Renderer>().enabled = false;

            if (Input.GetMouseButtonUp(1))
            {
                detectWhichPower();
            }
        }
    }
}
