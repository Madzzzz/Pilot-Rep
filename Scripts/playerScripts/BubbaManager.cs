using UnityEngine;
using System.Collections;

public class BubbaManager : MonoBehaviour {

    GameObject instance;

    public float posX;
    public float posY;
    public float posZ;
    public float rotX;
    public float rotY;

    public bool loaded = false;

    void Start ()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            instance = this.gameObject;
            var GameMusic = GameObject.Find("BubbaManager");
            var OldGameMusic = GameObject.Find("OldBubbaManager");
            if (GameMusic)
            {
                Destroy(OldGameMusic);
            }
        }

        this.gameObject.name = "OldBubbaManager";
        DontDestroyOnLoad(gameObject);
    }

    public void GetBubbaInfo(float px, float py, float pz, float rx, float ry)
    {
        posX = px;
        posY = py;
        posZ = pz;
        rotX = rx;
        rotY = ry;
    }

    public void PlaceBubba()
    {
        if (loaded == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().loadPos(posX, posY, posZ);
            Camera.main.GetComponent<MouseScript>().loadRot(rotX, rotY);
        }
        loaded = false;
    }
}
