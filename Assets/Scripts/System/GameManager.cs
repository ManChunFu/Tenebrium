using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeInPanel = null;
    [SerializeField] private GameObject fadeOutPanel = null;
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject crosshair = null;
    [SerializeField] private GameObject tutorial = null;
    [SerializeField] private GameObject settingPanel = null;
    [SerializeField] private PlayerView playerView = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private GameSetting gameSettingScriptable = null;
    [SerializeField] private GameEndScriptable gameEndScriptable = null;

    private bool playerFreeze = false;
    private void Awake()
    {
        if (gameSettingScriptable == null)
            throw new MissingReferenceException("Missing reference of GameSetting scriptable object.");

        if (gameEndScriptable == null)
            throw new MissingReferenceException("Missing reference of GameEndVOScriptable object");

        if (fadeInPanel == null)
            fadeInPanel = FindObjectOfType<Canvas>().transform.GetChild(5).gameObject;
    }

    private void Start()
    {
        if (!fadeInPanel.activeSelf)
            fadeInPanel.SetActive(true);

        fadeInPanel.GetComponent<FadeInOut>().SetFadeStatus(FadeStatus.FadeIn);

        if (gameSettingScriptable != null)
        {
            EnablePlayerJump();
            EnablePlayerSpeedUp();
        }
       
        if (pausePanel == null)
            pausePanel = FindObjectOfType<Canvas>().transform.GetChild(7).gameObject;

        if (pausePanel != null && pausePanel.activeSelf)
            pausePanel.SetActive(false);

        if (settingPanel == null)
            settingPanel = FindObjectOfType<Canvas>().transform.GetChild(3).gameObject;

        if (settingPanel != null && settingPanel.activeSelf)
            settingPanel.SetActive(false);

        if (crosshair == null)
            crosshair = FindObjectOfType<Canvas>().transform.GetChild(0).gameObject;

        if (tutorial == null)
            tutorial = FindObjectOfType<Canvas>().transform.GetChild(7).gameObject;

        if (playerView == null)
            playerView = FindObjectOfType<PlayerView>();

        if (playerController == null)
            playerController = FindObjectOfType<PlayerController>();

        if (fadeOutPanel == null)
            fadeOutPanel = FindObjectOfType<Canvas>().transform.GetChild(6).gameObject;

        if (fadeOutPanel.activeSelf)
            fadeOutPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.Sound.SFX.Pause.Post(gameObject);
            crosshair.SetActive(false);
            tutorial.SetActive(false);
            pausePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerView.enabled = false;
            Time.timeScale = 0;
        }
    }

    public void EnablePlayerJump()
    {
        playerController.EnableJump(gameSettingScriptable.EnablePlayerJump);
    }

    public void EnablePlayerSpeedUp()
    {
        playerController.EnableSpeedUp(gameSettingScriptable.EnablePlayerSpeedUp);
    }

    public void FreezePlayerMovement()
    {
        playerFreeze = true;
        playerController.enabled = false;
        playerView.enabled = false;
    }

    public void UnfreezePlayerMovement()
    {
        playerFreeze = false;
        playerController.enabled = true;
        playerView.enabled = true;
    }

    public void GameEnd(int endingType = 0)
    {
        if (endingType < 1 || endingType > 5)
        {
            Debug.LogError("EndingType number has to be between 1 and 5.");
            endingType = 1;
        }

        if (gameEndScriptable != null)
            gameEndScriptable.SetEndingType((EndingType)endingType);

        StartCoroutine(LoadGameEndCoroutine());
    }

    private IEnumerator LoadGameEndCoroutine()
    {
        fadeOutPanel.SetActive(true);
        fadeOutPanel.GetComponent<FadeInOut>().SetFadeStatus(FadeStatus.FadeOut);
        yield return new WaitUntil(() => fadeOutPanel.GetComponent<FadeInOut>().HasCompleted);
        SceneManager.LoadScene(2);
    }

    public void ResumeGame()
    {
        SoundManager.Sound.SFX.Unpause.Post(gameObject);
        pausePanel.SetActive(false);
        tutorial.SetActive(true);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (!playerFreeze)
            playerView.enabled = true;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
