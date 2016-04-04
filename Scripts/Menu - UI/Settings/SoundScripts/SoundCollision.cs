using UnityEngine;
using System.Collections;

public class SoundCollision : MonoBehaviour {

    private AudioSource source;

    void OnTriggerEnter()
    {
        source = GetComponent<AudioSource>();
        source.Stop();
        source.Play();
    }

    public void Pause()
    {
        source.Pause();
    }

    public void UnPause()
    {
        source.UnPause();
    }
}
