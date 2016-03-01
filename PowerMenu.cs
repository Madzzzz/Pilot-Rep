using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerMenu : MonoBehaviour {
    //Powermenyen med knapper
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
        //powerMenu.enabled = false;
        anger = anger.GetComponent<Button>();
        fear = fear.GetComponent<Button>();
        regret = regret.GetComponent<Button>();
        depression = depression.GetComponent<Button>();
        ecstacy = ecstacy.GetComponent<Button>();
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
