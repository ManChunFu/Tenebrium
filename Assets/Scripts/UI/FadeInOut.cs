using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum FadeStatus
{
    FadeIn,
    FadeOut
}
public class FadeInOut : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.03f;
    [SerializeField] private Image image = null;
    public bool HasCompleted { get; private set; }
    private FadeStatus fadeStatus = FadeStatus.FadeOut;
    private void Awake()
    {
        if (image == null)
            image = GetComponent<Image>();
    }

    private void Start()
    {
        HasCompleted = false;

        if (fadeStatus == FadeStatus.FadeIn)
            StartCoroutine(FadeInCoroutine());
        else
            StartCoroutine(FadeOutCoroutine());
    }

    public void SetFadeStatus(FadeStatus status)
    {
        fadeStatus = status;
    }

    private IEnumerator FadeInCoroutine()
    {
        for (float a = 1; a >= 0f; a -= 0.03f)
        {
            image.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.05f);
        }
        HasCompleted = true;
        gameObject.SetActive(false);
    }

    private IEnumerator FadeOutCoroutine()
    {
        for (float a = 0; a <= 1f; a += 0.03f)
        {
            image.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.05f);
        }
        HasCompleted = true;
    }
}
