using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public Canvas Settings;

	void Start ()
    {
        GameObject.Find("OldGameMusic").GetComponent<StayAlive>().show();
        Settings.enabled = true;
    }

    public void LeaveSettings()
    {
        GameObject.Find("OldGameMusic").GetComponent<StayAlive>().noShow();
        Settings.enabled = false;
    }
}
