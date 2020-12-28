using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class SliderFunctions : MonoBehaviour
{
    public Slider slider;
    [SerializeField] CountDownTimer timer;
    private void Awake()
    {
        timer.tValueNormalized += UpdateSlider; 
    }
    void UpdateSlider(float value)
    {
        slider.value = value;
    }
}
