using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerMenu : MonoBehaviour {

    public Canvas powerMenu;
    public Button anger;
    public Button fear;
    public Button regret;
    public Button depression;
    public Button ecstacy;
    bool escapePressed;
    Depression depressionScript;

    void Start()
    {
        powerMenu = powerMenu.GetComponent<Canvas>();
        powerMenu.enabled = false;
        anger = anger.GetComponent<Button>();
        fear = fear.GetComponent<Button>();
        regret = regret.GetComponent<Button>();
        depression = depression.GetComponent<Button>();
        ecstacy = ecstacy.GetComponent<Button>();
    }

    public void Anger()
    {
        Debug.Log("FEEL THE BERN");
        Camera.main.GetComponent<GrabbingAndDropping>().rage = true;
    }

    public void Fear()
    {
        Debug.Log("DEUS VULT");
        Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
    }

    public void Regret()
    {
        Debug.Log("NO REGRATS");
        Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
    }

    public void Depression()
    {
        Debug.Log("ME IRL");
        Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
        depression.GetComponent<Depression>().depresionOn = true;
    }

    public void Ecstacy()
    {
        Debug.Log("CANT STUMP THE TRUMP");
        Camera.main.GetComponent<GrabbingAndDropping>().rage = false;
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

            if (Input.GetMouseButtonUp(1))
            {
                //detectWhichPower();
            }
        }
    }
}
