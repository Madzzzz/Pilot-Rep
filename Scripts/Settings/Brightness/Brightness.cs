using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brightness : MonoBehaviour {

    public float GammaCorrection;
    public Slider BrightnessSlider;

    void Update()
    {
        GammaCorrection = BrightnessSlider.value;
        RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection, 1.0f);

    }
}
