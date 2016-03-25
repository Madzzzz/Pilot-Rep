using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StayAlive : MonoBehaviour {

    GameObject instance;
    public float Vol;
    public Slider VolSlider;
    public float MusicVol;
    public Slider MusicSlider;
    public Canvas soundslider;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            instance = this.gameObject;
            var GameMusic = GameObject.Find("GameMusic");
            var OldGameMusic = GameObject.Find("OldGameMusic");
            if (GameMusic)
            {
                Destroy(OldGameMusic);
            }
        }

        if (GameObject.Find("OldGameMusic") != null)
        {
            VolSlider.value = GameObject.Find("OldGameMusic").GetComponent<StayAlive>().Vol;
            MusicSlider.value = GameObject.Find("OldGameMusic").GetComponent<StayAlive>().MusicVol;
        }

        this.gameObject.name = "OldGameMusic";

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Vol = VolSlider.value;
        MusicVol = MusicSlider.value;
        AudioListener.volume = Vol;
    }

    public void show()
    {
        soundslider.enabled = true;
    }

    public void noShow()
    {
        soundslider.enabled = false;
    }
}
