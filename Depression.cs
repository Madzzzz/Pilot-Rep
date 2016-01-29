using UnityEngine;
using System.Collections;

public class Depression : MonoBehaviour {

    public void TransparentOn()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }
        
    }

    public void TransparentOff()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
