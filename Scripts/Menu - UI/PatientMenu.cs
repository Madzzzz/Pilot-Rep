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

    IEnumerator ReturnPress()
    {
        
        Selected.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
        yield return new WaitForSeconds(2.0f);
        Main.enabled = true;
    }

    IEnumerator Select1()
    {
        Main.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
        yield return new WaitForSeconds(2.5f);
        Selected1.enabled = true;
        Selected.enabled = true;
    }

    IEnumerator Select2()
    {
        Main.enabled = false;
        Selected1.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
        yield return new WaitForSeconds(1.5f);
        Selected2.enabled = true;
        Selected.enabled = true;
    }

    IEnumerator Select3()
    {
        Main.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected4.enabled = false;
        yield return new WaitForSeconds(1.5f);
        Selected3.enabled = true;
        Selected.enabled = true;
    }

    IEnumerator Select4()
    {
        Main.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        yield return new WaitForSeconds(2.5f);
        Selected4.enabled = true;
        Selected.enabled = true;
    }

    public void InitReturn()
    {
        StartCoroutine(ReturnPress());
    }

    public void Init1()
    {
        StartCoroutine(Select1());
    }

    public void Init2()
    {
        StartCoroutine(Select2());
    }

    public void Init3()
    {
        StartCoroutine(Select3());
    }

    public void Init4()
    {
        StartCoroutine(Select4());
    }

    public void GameStart()
    {
        Selected.enabled = false;
        Selected1.enabled = false;
        Selected2.enabled = false;
        Selected3.enabled = false;
        Selected4.enabled = false;
        Main.enabled = false;
    }

}
