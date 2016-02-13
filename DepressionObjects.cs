using UnityEngine;
using System.Collections;

public class DepressionObjects : MonoBehaviour {

    //Gjøre depression-objekter igjennomsiktige

    public bool transformed = false;

    void Update()
    {
        if (transformed == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }

        if (transformed == false)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
