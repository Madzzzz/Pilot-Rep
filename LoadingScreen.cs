using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {
    public GameObject background;
    public GameObject text;
    public GameObject progressbar;

    private int loadProgress = 0;

    // Use this for initialization
    void Start () {
        background.SetActive(false);
	    text.SetActive(false);
        progressbar.SetActive(false);
    }

    public void startLoad()
    {
        StartCoroutine(DisplayLoadingScreen("PlaceHolderLevel"));
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
