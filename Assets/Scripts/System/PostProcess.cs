using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PostProcess : MonoBehaviour
{
    [SerializeField] PostProcessVolume postVolume;
    ColorGrading colorGrading;
    [SerializeField] GameSetting settings;


    private void Awake()
    {
        postVolume.profile.TryGetSettings(out colorGrading);
    }

    public void ChangeGammaValue(float value)
    {
        colorGrading.gamma.value.w = value;
        settings.ChangeLightIntens(value);
    }
}
