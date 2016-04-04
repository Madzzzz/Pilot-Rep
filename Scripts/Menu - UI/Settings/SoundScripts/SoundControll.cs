using UnityEngine;
using System.Collections;

public class SoundControll : MonoBehaviour {

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Stop();
        source.Play();
        source.loop = true;
    }


    public void StopSound()
    {
        source.Pause();
    }

    public void StartSound()
    {
        source.UnPause();
    }
}
