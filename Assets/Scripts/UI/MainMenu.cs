using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject choicePanel = null;
    [SerializeField] private GameObject fadeOutPanel = null;
    [SerializeField] private GameSetting gameSettingScriptable = null;
    [SerializeField] private MainManuSoundManager soundManager = null;
    [SerializeField] private float defaultLightIntensity = 5.0f;

    public Slider lightSlider;
    public Toggle[] resolutionToggles;
    public int[] screenW;
    public Toggle fullscreenToggle;

    private int setActiveResolution;
    private Light[] allLights;

    private bool defaultPlayerJump = false;
    private bool defaultPlayerSpeedUp = false;

    private void Awake()
    {
        if (choicePanel == null)
            choicePanel = transform.GetChild(1).gameObject;

        if (choicePanel != null && choicePanel.activeSelf)
            choicePanel.SetActive(false);

        if (fadeOutPanel == null)
            fadeOutPanel = transform.GetChild(2).gameObject;

        if (fadeOutPanel != null && fadeOutPanel.activeSelf)
            fadeOutPanel.SetActive(false);


        allLights = FindObjectsOfType<Light>();
        lightSlider = GetComponent<Slider>();
        gameSettingScriptable.LightIntensity = defaultLightIntensity;

        gameSettingScriptable.EnablePlayerJump = defaultPlayerJump;
        gameSettingScriptable.EnablePlayerSpeedUp = defaultPlayerSpeedUp;
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        setActiveResolution = PlayerPrefs.GetInt("Screen Resolution Index");
        bool isFullScreen = (PlayerPrefs.GetInt("Fullscreen") == 1) ? true : false;

        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == setActiveResolution;
        }
        fullscreenToggle.isOn = isFullScreen;

        if (soundManager == null)
            soundManager = FindObjectOfType<MainManuSoundManager>();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCorroutine());
    }

    private IEnumerator StartGameCorroutine()
    {
        choicePanel.SetActive(true);
        soundManager.FadeOut();
        yield return new WaitUntil(() => choicePanel.GetComponent<DisplayChoice>().HasCompleted);
        SceneManager.LoadSceneAsync(1);
    }


    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    private IEnumerator QuitGameCoroutine()
    {
        fadeOutPanel.SetActive(true);
        fadeOutPanel.GetComponent<FadeInOut>().SetFadeStatus(FadeStatus.FadeOut);
        soundManager.FadeOut();
        yield return new WaitUntil(() => fadeOutPanel.GetComponent<FadeInOut>().HasCompleted);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    public void SetScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            setActiveResolution = i;
            float aspRatScreen = 16 / 9f;
            Screen.SetResolution(screenW[i], (int)(screenW[i] / aspRatScreen), false);
            PlayerPrefs.SetInt("Screen Reselutions Index", setActiveResolution);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullScreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullScreen;
        }

        if (isFullScreen)
        {
            Resolution[] theResolutions = Screen.resolutions;
            Resolution maxResolution = theResolutions[theResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(setActiveResolution);
        }
        PlayerPrefs.SetInt("Fullscreen", ((isFullScreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void OnChangedIntensity(float value)
    {

        foreach (var l in allLights)
        {
            l.intensity = value;
        }

        gameSettingScriptable.ChangeLightIntens(value);

    }

    private void OnEnable()
    {
        BrightnessSlider.valueChanged += OnChangedIntensity;
    }

    private void OnDisable()
    {
        BrightnessSlider.valueChanged -= OnChangedIntensity;
    }
}
