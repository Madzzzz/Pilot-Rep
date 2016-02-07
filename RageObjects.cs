using UnityEngine;
using System.Collections;

public class RageObjects : MonoBehaviour {

    public bool rageOnObject = false;

    void Grow()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 2, gameObject.transform.localScale.y * 2, gameObject.transform.localScale.z * 2);
    }

    void Shrink()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2, gameObject.transform.localScale.z / 2);
    }

    public void RageAffect()
    {
        if (rageOnObject == true)
            Grow();
        

        if (rageOnObject == false)
            Shrink();

        rageOnObject = !rageOnObject;
    }
}
