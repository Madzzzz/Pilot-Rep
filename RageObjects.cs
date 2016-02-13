using UnityEngine;
using System.Collections;

public class RageObjects : MonoBehaviour {

    public bool rageOnObject = false;
    Vector3 DoubbleSize;
    Vector3 HalfSize;

    void Start()
    {
        DoubbleSize = gameObject.transform.localScale * 2;
        HalfSize = gameObject.transform.localScale / 2;
    }

    void Grow()
    {
        /*for (int i = 1; i <= 100; i++)
        {
            gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);
            yield return new WaitForSeconds(0.001f);
        }*/
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 2, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z * 2);
    }

    void Shrink()
    {
        /*for (int i = 1; i <= 100; i++)
        {
            gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);
            yield return new WaitForSeconds(0.001f);
        }*/
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2, gameObject.transform.localScale.z / 2);
    }

    public void RageAffect()
    {
        if (rageOnObject == true)
            Grow();


        if (rageOnObject == false)
            Shrink();

        rageOnObject = !rageOnObject;
    }

    void Update()
    {
        if (Camera.main.GetComponent<MouseScript>().escapePressed == false)
        {
            if (rageOnObject == true)
                if (gameObject.transform.localScale.x <= DoubbleSize.x)
                    gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);


            if (rageOnObject == false)
                if (gameObject.transform.localScale.x >= HalfSize.x)
                    gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);

        }
    }
}
