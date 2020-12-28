using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text displayText = null;

    private void Awake()
    {
        if (displayText == null)
            throw new MissingReferenceException("Missing reference of Display_text on Canvas");

        if (displayText != null)
            displayText.enabled = false;
    }


    public void StartDisplayInfo(string displayInfo, Color textColor, Font textFont, FontStyle fontStyle, int fontSize, float secondsToClearText)
    {
        StartCoroutine(DisplayInfo(displayInfo, textColor, textFont, fontStyle, fontSize, secondsToClearText));
    }


    private IEnumerator DisplayInfo(string displayInfo, Color textColor, Font textFont, FontStyle fontStyle, int fontSize, float secondsToClearText)
    {
        displayText.enabled = true;
        displayText.text = displayInfo;
        displayText.color = textColor;
        displayText.font = textFont;
        displayText.fontStyle = fontStyle;
        displayText.fontSize = fontSize;
        displayText.alignment = TextAnchor.MiddleCenter;

        yield return new WaitForSeconds(secondsToClearText);

        if (secondsToClearText > 0)
        {
            displayText.text = "";
            displayText.enabled = false;
        }
    }
}
