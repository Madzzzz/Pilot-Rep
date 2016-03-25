using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLogo : MonoBehaviour {

    public Canvas StartMenu;

    void Start()
    {
        ShuldDeleteStartLogo();
    }

    IEnumerator DeleteSelfAfterPlay()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();
        movie.Play();
        yield return new WaitForSeconds(5);
        StartMenu.enabled = true;
        Destroy(gameObject);
    }

    void DeleteSelfBeforePlay()
    {
        StartMenu.enabled = true;
        Destroy(gameObject);
    }

    void ShuldDeleteStartLogo()
    {
        var GameMusic = GameObject.Find("BubbaManager");
        var OldGameMusic = GameObject.Find("OldBubbaManager");

        if (GameMusic)
        {
            StartCoroutine(DeleteSelfAfterPlay());
        }
        if (OldGameMusic)
        {
            DeleteSelfBeforePlay();
        }
            
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            DeleteSelfBeforePlay();
        }
    }
}
