using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class EndGame
{
    public EndingType endingType;
    public PlayableDirector timeline;
}

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject fadeInPanel = null;
    [SerializeField] private GameObject fadeOutPanel = null;
    [SerializeField] private GameObject creditPanel = null;
    [SerializeField] private GameEndScriptable gameEndScriptable = null;
    [SerializeField] private EndGame[] endGame = default;
    [SerializeField] private EndingType selectedEndingType = default;

    private Dictionary<EndingType, PlayableDirector> endGameData;

    private void Awake()
    {
        endGameData = endGame.ToDictionary(et => et.endingType, tl => tl.timeline);

        if (fadeInPanel == null)
            fadeInPanel = transform.GetChild(1).gameObject;

        if (fadeOutPanel == null)
            fadeOutPanel = transform.GetChild(2).gameObject;

        if (fadeOutPanel.activeSelf)
            fadeOutPanel.SetActive(false);

        if (creditPanel == null)
            creditPanel = transform.GetChild(3).gameObject;

        if (creditPanel.activeSelf)
            creditPanel.SetActive(false);

        if (gameEndScriptable == null)
            throw new MissingReferenceException("Missing reference of GameEndVOScriptable object");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (!fadeInPanel.activeSelf)
            fadeInPanel.SetActive(true);

        StartCoroutine(PlayEndingScript());
    }

    private IEnumerator PlayEndingScript()
    {
        fadeInPanel.GetComponent<FadeInOut>().SetFadeStatus(FadeStatus.FadeIn);
        yield return new WaitUntil(() => fadeInPanel.GetComponent<FadeInOut>().HasCompleted);

        if (gameEndScriptable != null)
            selectedEndingType = gameEndScriptable.selectedEndingType;
        
        endGameData[selectedEndingType].Play();
        PlayableDirector timelineClip = endGameData[selectedEndingType];
        float clipLength = (float)timelineClip.duration;
        yield return new WaitForSeconds(clipLength);

        StartCoroutine(RunCredits());
    }

    private IEnumerator RunCredits()
    {
        fadeOutPanel.SetActive(true);
        fadeOutPanel.GetComponent<FadeInOut>().SetFadeStatus(FadeStatus.FadeOut);
        yield return new WaitUntil(() => fadeInPanel.GetComponent<FadeInOut>().HasCompleted);

        creditPanel.SetActive(true);
    }
}
