using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChoice : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.03f;
    [SerializeField] private float timeForFadeOut = 2.0f;
    [SerializeField] private Text textChoice1 = null;
    [SerializeField] private Text textChoice2 = null;

    public bool HasCompleted { get; private set; }
    private void Awake()
    {
        if (textChoice1 == null)
            textChoice1 = transform.GetChild(0)?.GetComponent<Text>();

        if (textChoice2 == null)
            textChoice2 = transform.GetChild(1)?.GetComponent<Text>();
    }

    private void Start()
    {
        HasCompleted = false;
        StartCoroutine(ChoiceDisplayCoroutine());
    }
    private IEnumerator ChoiceDisplayCoroutine()
    {
        for (float a = 0; a <= 1; a += fadeSpeed)
        {
            textChoice1.color = new Color(255, 255, 255, a);
            textChoice2.color = new Color(255, 255, 255, a);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(timeForFadeOut);

        for (float a = 1; a >= 0f; a -= fadeSpeed)
        {
            textChoice1.color = new Color(255, 255, 255, a);
            textChoice2.color = new Color(255, 255, 255, a);
            yield return new WaitForSeconds(0.01f);
        }

        HasCompleted = true;
    }
}
