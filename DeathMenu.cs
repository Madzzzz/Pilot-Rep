using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
    
    public Button Load;
    public Button Exit;
    public Canvas DeathScreen;

    void Start()
    {
        Load = Load.GetComponent<Button>();
        Exit = Exit.GetComponent<Button>();
        DeathScreen.enabled = false;
    }

    public void Dead()
    {
        DeathScreen.enabled = true;
    }

    public void ExitPress()
    {
        SceneManager.LoadScene(0);
    }
}
