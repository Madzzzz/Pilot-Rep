using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    //PauseMeny

    public Button Resume;
    public Button Load;
    public Button Exit;
    public Canvas PauseScreen;
    public Canvas SoundSlider;

    void Start () {
        Resume = Resume.GetComponent<Button>();
        Load = Load.GetComponent<Button>();
        Exit = Exit.GetComponent<Button>();
        PauseScreen.enabled = false;
    }

    public void Pause()
    {
        PauseScreen.enabled = true;
        SoundSlider.enabled = true;
    }

    public void Unpause()
    {
        PauseScreen.enabled = false;
        SoundSlider.enabled = false;
    }
}
