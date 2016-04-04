using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PowerMenu : MonoBehaviour {
    
    public Canvas powerMenu;
    public Button anger;
    public Button fear;
    public Button regret;
    public Button depression;
    public Button ecstacy;
    bool escapePressed;

    void Start()
    {
        powerMenu = powerMenu.GetComponent<Canvas>();
        anger = anger.GetComponent<Button>();
        fear = fear.GetComponent<Button>();
        regret = regret.GetComponent<Button>();
        depression = depression.GetComponent<Button>();
        ecstacy = ecstacy.GetComponent<Button>();

        CheckWhichLevel();
    }

    void CheckWhichLevel()
    {
        if (SceneManager.GetActiveScene().name == "PlaceHolderLevel")
        {
            fear.enabled = false;
            ecstacy.enabled = false;
            regret.enabled = false;
            fear.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
            regret.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
            ecstacy.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            ecstacy.enabled = false;
            regret.enabled = false;
        }

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            regret.enabled = false;
        }

        if (SceneManager.GetActiveScene().name == "Level4")
        {

        }
    }

    void Update()
    {

        escapePressed = Camera.main.GetComponent<MouseScript>().escapePressed;

        if (escapePressed == false)
        {
            if (Input.GetMouseButton(1))
                powerMenu.enabled = true;
            else
                powerMenu.enabled = false;
        }
    }
}
