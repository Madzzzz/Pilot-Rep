using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PatientMenu : MonoBehaviour {

    public Canvas Main;
    public Canvas Selected;
    public Canvas Selected1;
    public Canvas Selected2;
    public Canvas Selected3;
    public Canvas Selected4;
    public Button Return;
    public Button ToMenu;

    void Start()
    {
        Time.timeScale = 1.0f;
        Main = Main.GetComponent<Canvas>();

        Selected.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
    }

    public void ReturnPress()
    {
        Main.enabled = true;
        Selected.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
    }

    public void Select1()
    {
        Main.enabled = false;
        Selected1.enabled = true;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
        Selected.enabled = true;
    }

    public void Select2()
    {
        Main.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = true;
        Selected3.enabled = false;
        Selected4.enabled = false;
        Selected.enabled = true;
    }

    public void Select3()
    {
        Main.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = true;
        Selected4.enabled = false;
        Selected.enabled = true;
    }

    public void Select4()
    {
        Main.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = true;
        Selected.enabled = true;
    }

}
