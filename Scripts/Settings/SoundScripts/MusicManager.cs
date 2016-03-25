using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public AudioClip NewMusic; //Pick an audio track to play.

    void Start()
    {
        //Finds the game object called Game Music, if it goes by a different name, change this. 
        //GameObject.Find("GameMusic").GetComponent<AudioSource>().clip = NewMusic; //Replaces the old audio with the new one set in the inspector. 
        //GameObject.Find("GameMusic").GetComponent<AudioSource>().Play(); //Plays the audio. } 
    }
}
