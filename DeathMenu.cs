using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
    
    public Button Load;
    public Button Exit;
    public Button Restart;
    public Canvas DeathScreen;

    void Start()
    {
        Restart = Restart.GetComponent<Button>();
        Load = Load.GetComponent<Button>();
        Exit = Exit.GetComponent<Button>();
        DeathScreen.enabled = false;
    }

}
