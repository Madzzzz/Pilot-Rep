using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LoadingScreen : MonoBehaviour {

    public GameObject background;
    public GameObject text;
    public GameObject progressbar;

    

    private int loadProgress = 0;

    // Loading screen med progress-bar
    void Start () {
        background.SetActive(false);
	    text.SetActive(false);
        progressbar.SetActive(false);
    }

    public void load1()
    {
        StartCoroutine(DisplayLoadingScreen("Level 1"));
    }

    public void load2()
    {
        StartCoroutine(DisplayLoadingScreen("Level 2"));
    }

    public void load3()
    {
        StartCoroutine(DisplayLoadingScreen("Level 3"));
    }

    public void load4()
    {
        StartCoroutine(DisplayLoadingScreen("Level 4"));
    }

    public void loadSave()
    {
        StartCoroutine(DisplayLoadingScreen("PlaceHolderLevel"));
    }

    public void loadFinish()
    {
        StartCoroutine(DisplayLoadingScreen("LevelDoneScreen1"));
    }

    public void returnToMenu()
    {
        StartCoroutine(DisplayLoadingScreen("StartMenu"));
    }

    public void reloadCurrent()
    {
        StartCoroutine(DisplayLoadingScreen(Application.loadedLevelName));

        //Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene);
    }

    IEnumerator DisplayLoadingScreen(string level)
    {
        background.SetActive(true);
        text.SetActive(true);
        progressbar.SetActive(true);

        progressbar.transform.localScale = new Vector3(loadProgress, progressbar.transform.localScale.y, progressbar.transform.localScale.z);

        text.GetComponent<GUIText>().text = "Loading Progress: " + loadProgress + "%";

        AsyncOperation async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            text.GetComponent<GUIText>().text = "Loading Progress: " + loadProgress + "%";
            progressbar.transform.localScale = new Vector3(async.progress, progressbar.transform.localScale.y, progressbar.transform.localScale.z);
            yield return null;
        }

        

    }
}
