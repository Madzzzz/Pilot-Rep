using UnityEngine;
using System.Collections;

public class PlaceholderWin : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "winCrystal")
        {
            Debug.Log("Yay you won");
        }
    }
}
