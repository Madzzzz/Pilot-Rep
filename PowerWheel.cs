using UnityEngine;
using System.Collections;

public class PowerWheel : MonoBehaviour {

    bool escapePressed = false;

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
            }

            if (hit.transform.name == "Fear")
            {
                Debug.Log("DEUS VULT");
            }

            if (hit.transform.name == "Happy")
            {
                Debug.Log("CANT STUMP THE TRUMP");
            }

            if (hit.transform.name == "Depression")
            {
                Debug.Log("ME IRL");
            }

            if (hit.transform.name == "Regret")
            {
                Debug.Log("NO REGRATS");
            }
        }

        
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            escapePressed =! escapePressed;

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
