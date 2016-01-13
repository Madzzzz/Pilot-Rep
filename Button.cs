using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    
    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && Input.GetKeyDown("e"))
        {
            GameObject.Find("WinWallStuff").GetComponent<PlaceholderWinWall>().moveTheWall();
        }
    }
    
}
