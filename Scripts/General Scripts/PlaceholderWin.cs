using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlaceholderWin : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "winCrystal")
        {
            Debug.Log("Yay you won");
        }
        //SceneManager.LoadScene(2);
    }
}
