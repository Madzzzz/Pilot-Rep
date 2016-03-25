using UnityEngine;
using System.Collections;

public class PlayMovieTexture : MonoBehaviour {

    void Start()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();
        movie.Play();
        movie.loop = true;
    }

    public void PauseSpaceWalrus()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        
        movie.Pause();
    }

    public void UnPauseSpaceWalrus()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;

        movie.Play();
    }
}
