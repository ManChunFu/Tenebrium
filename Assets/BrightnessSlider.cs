using System;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{

    public static Action<float> valueChanged = delegate { };
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(sliderValueChanged);
    }

    private void sliderValueChanged(float arg0)
    {
        valueChanged(arg0);
    }
}
