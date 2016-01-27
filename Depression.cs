using UnityEngine;
using System.Collections;

public class Depression : MonoBehaviour {

    public bool depresionOn = false;
    bool grow = false;
    bool shrink = false;

    void Update()
    {

        if (depresionOn == true)
        {
            //gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            grow = false;
            if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x >= 1.0f)
                shrink = true;
            Debug.Log("SO SAD " + gameObject);
        }


        if (depresionOn == false)
        {
            //gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            shrink = false;
            if (GameObject.FindGameObjectWithTag("Player").transform.localScale.x <= 0.7f)
                grow = true;
            Debug.Log("SO UNSAD " + gameObject);
        }

        if(grow == true)
            GameObject.FindGameObjectWithTag("Player").transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

        if(shrink == true)
            GameObject.FindGameObjectWithTag("Player").transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
    }
}
