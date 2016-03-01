using UnityEngine;
using System.Collections;

public class RageObjects : MonoBehaviour {

    public bool rageOnObject = false;
    Vector3 RageSize;
    Vector3 NormalSize;

    void Start()
    {
        RageSize = gameObject.transform.localScale * 2;
        NormalSize = gameObject.transform.localScale;
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
        
            if (rageOnObject == true)
                if (gameObject.transform.localScale.x <= RageSize.x)
                    gameObject.transform.localScale += new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);


            if (rageOnObject == false)
                if (gameObject.transform.localScale.x >= NormalSize.x)
                    gameObject.transform.localScale -= new Vector3(gameObject.transform.localScale.x / 100, gameObject.transform.localScale.y / 100, gameObject.transform.localScale.z / 100);

        
    }
}
