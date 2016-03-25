using UnityEngine;
using System.Collections;

public class Regret : MonoBehaviour {

    public bool regretOn = false;

    public void StartRegret()
    {
        regretOn = true;
    }

    public void StopRegret()
    {
        regretOn = false;
    }

    void Update()
    {
        if (Camera.main.GetComponent<MouseScript>().escapePressed == false && Camera.main.GetComponent<MouseScript>().powerMenu == false)
        {

            if (regretOn == true)
            {
                if (Input.GetKey("q"))
                {
                    Time.timeScale = 0.2f;
                }

                else
                    Time.timeScale = 1.0f;
            }
        }
    }
}
