using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManuSoundManager : MonoBehaviour
{
    [SerializeField] AK.Wwise.Bank MainBank;
    [SerializeField] AK.Wwise.Event MainMenuAmbience;
    [SerializeField] AK.Wwise.Event MainMenuMusic;
    [SerializeField] AK.Wwise.Event ClickUI;
    [SerializeField] AK.Wwise.Event QuitFade;

    private void Awake()
    {
        MainBank.Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        MainMenuAmbience.Post(gameObject);
        MainMenuMusic.Post(gameObject);
    }

    public void UIClick()
    {
        ClickUI.Post(gameObject);
    }

    //Sound options
    public void SetMasterVolume(float Volume)
    {
        AkSoundEngine.SetRTPCValue("MasterVolume", Volume);
    }

    public void SetEffectsVolume(float Volume)
    {
        AkSoundEngine.SetRTPCValue("EffectsVolume", Volume);
    }

    public void SetAmbienceVolume(float Volume)
    {
        AkSoundEngine.SetRTPCValue("AmbientVolume", Volume);
    }

    public void SetMusicVolume(float Volume)
    {
        AkSoundEngine.SetRTPCValue("MusicVolume", Volume);
    }

    public void SetVoiceVolume(float Volume)
    {
        AkSoundEngine.SetRTPCValue("VoiceVolume", Volume);
    }

    public void FadeOut()
    {
        QuitFade.Post(gameObject);
    }
}
