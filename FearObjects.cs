using UnityEngine;
using System.Collections;

public class FearObjects : MonoBehaviour {

    public Renderer rend;
    public Texture[] texture;

    public bool fearOnObject = false;
    Vector3 FearSize;
    Vector3 NormalSize;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        FearSize = gameObject.transform.localScale / 2;
        NormalSize = gameObject.transform.localScale;
    }
    
    public void Fear()
    {
        if (gameObject.tag == ("FearShrink"))
        {
            return;
        }

        else
        {
            if (Camera.main.GetComponent<MouseScript>().escapePressed == false)
            {
                if (gameObject.GetComponent<Light>().enabled == false)
                {
                    gameObject.GetComponent<Light>().enabled = true;
                    rend.material.mainTexture = texture[0];
                    return;
                }
            }
        }
    }

    public void FearAffect()
    {

        fearOnObject = !fearOnObject;
    }

    public void FearStop()
    {
        if (gameObject.tag == ("FearShrink"))
        {
            return;
        }

        else
        {
            if (gameObject.GetComponent<Light>().enabled == true)
            {
                gameObject.GetComponent<Light>().enabled = false;
                rend.material.mainTexture = texture[1];
                return;
            }
        }
    }

    void Update()
    {

        if (fearOnObject == true)
            if (gameObject.transform.localScale.x >= FearSize.x)
                gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);


        if (fearOnObject == false)
            if (gameObject.transform.localScale.x <= NormalSize.x)
                gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);


    }
}
