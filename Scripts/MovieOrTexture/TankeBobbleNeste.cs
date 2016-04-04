using UnityEngine;
using System.Collections;

public class TankeBobbleNeste : MonoBehaviour {

    void Start()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();
        movie.Play();
        movie.loop = true;
    }
}
