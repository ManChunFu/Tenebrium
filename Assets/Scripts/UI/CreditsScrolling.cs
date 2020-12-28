using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScrolling : MonoBehaviour
{
    [SerializeField] private GameObject fadeOutPanel = null;
    [Min(1.5f)]
    [SerializeField] private GameObject creditPanel = null;
    [SerializeField] private float timeForFadeOut = 1.5f;
    [SerializeField] private Image imageDisplay = null;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private float timeForSwitchImage = 3.0f;
    [SerializeField] private float imageFadeRate = 0.03f;

    private Animator animator = null;
    private float creditNamesClipLength = 0.0f;
    private void Awake()
    {
        if (fadeOutPanel == null)
            fadeOutPanel = transform.GetChild(2).gameObject;

        if (fadeOutPanel.activeSelf)
            fadeOutPanel.SetActive(false);

        animator = transform.GetChild(1)?.GetComponent<Animator>();
        creditNamesClipLength = animator.runtimeAnimatorController.animationClips.Length;
    }
    private void Start()
    {
        StartCoroutine(ScrollingImages());
    }

    private IEnumerator ScrollingImages()
    {
        if (sprites.Count < 0)
            yield break;

        int spriteIndex = sprites.Count - 1;
        int index = 0;

        while (spriteIndex >= 0)
        {
            imageDisplay.sprite = sprites[index];
            for (float a = 0; a <= 1; a += 0.01f)
            {
                imageDisplay.color = new Color(255, 255, 255, a);
                yield return new WaitForSeconds(imageFadeRate);
            }
            yield return new WaitForSeconds(timeForSwitchImage);
            for (float a = 1; a >= 0.01f; a -= 0.01f)
            {
                imageDisplay.color = new Color(255, 255, 255, a);
                yield return new WaitForSeconds(imageFadeRate);
            }
            index++;
            spriteIndex--;
        }

        yield return new WaitForSeconds(creditNamesClipLength);
        yield return SceneManager.LoadSceneAsync(0);
    }

    public void BackToMainMenu()
    {
        StopAllCoroutines();
        StartCoroutine(BackToMainMenuCoroutine());
    }

    private IEnumerator BackToMainMenuCoroutine()
    {
        fadeOutPanel.SetActive(true);
        fadeOutPanel.GetComponent<FadeInOut>().SetFadeStatus(FadeStatus.FadeOut);
        yield return new WaitUntil(()=>fadeOutPanel.GetComponent<FadeInOut>().HasCompleted);
        SceneManager.LoadScene(0);
    }
}
