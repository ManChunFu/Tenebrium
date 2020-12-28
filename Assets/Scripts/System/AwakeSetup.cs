
using UnityEngine;
using UnityEngine.UI;
public class AwakeSetup : MonoBehaviour
{
    [SerializeField] GameSetting settings;
    [SerializeField] Slider gammaSlider;
    void Start()
    {
        gammaSlider.value = settings.LightIntensity;
    }

}
