using UnityEngine;
using System.Collections;

public class PowerWheel : MonoBehaviour {    

    void Start() {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
	
	void Update () {

        if (Input.GetMouseButton (1)) 
            gameObject.GetComponent<Renderer>().enabled = true;
        else
            gameObject.GetComponent<Renderer>().enabled = false;

        /*
        
        if (gameObject.tag == ("Happy"))
            Debug.Log("HAPPY POWER ACTIVATE");
        if (gameObject.tag == ("Depression"))
            Debug.Log("DEPRESSION POWER ACTIVATE");
        if (gameObject.tag == ("Fear"))
            Debug.Log("FEAR POWER ACTIVATE");
        if (gameObject.tag == ("Rage"))
            Debug.Log("RAGE POWER ACTIVATE");
        if (gameObject.tag == ("Regret"))
            Debug.Log("REGRET POWER ACTIVATE");

        */


    }
}
