using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text text = null;
    [SerializeField] private Color mouseOverColor = default;
    [SerializeField] private int fontSizeMouseOver = 40;

    private Color m_StartColor = default;
    private int m_StartFontSize = 30;

    private void Awake()
    {
        if (text == null)
        {
            throw new MissingReferenceException("Missing reference of Text game object.");
        }
        m_StartColor = text.color;
        m_StartFontSize = text.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = mouseOverColor;
        text.fontSize = fontSizeMouseOver;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = m_StartColor;
        text.fontSize = m_StartFontSize;
    }
}
