using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Button Resume;
    public Button Load;
    public Button Exit;
    public Canvas PauseScreen;

    void Start () {
        Resume = Resume.GetComponent<Button>();
        Load = Load.GetComponent<Button>();
        Exit = Exit.GetComponent<Button>();
        PauseScreen.enabled = false;
    }

    public void Pause()
    {
        PauseScreen.enabled = true;
    }

    public void Unpause()
    {
        PauseScreen.enabled = false;
        Input.GetButtonDown("Escape");
    }

    /*public void ExitPress()
    {
        SceneManager.LoadScene(0);
    }*/
}
