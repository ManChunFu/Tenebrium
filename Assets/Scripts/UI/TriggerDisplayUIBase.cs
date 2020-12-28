using UnityEngine;

public abstract class TriggerDisplayUIBase : MonoBehaviour
{
    [SerializeField] protected UIManager uiManager = null;
    [SerializeField] protected bool triggerOnce = false;

    [SerializeField] protected bool displayMessage = false;
    [TextArea]
    [SerializeField] protected string displayInfo = "";
    [SerializeField] protected Font textFont = default;
    [SerializeField] protected int fontSize = 14;
    [SerializeField] protected FontStyle fontStyle = default;
    [SerializeField] protected Color textColor = Color.red;
    [SerializeField] protected float secondsToClearText = 3.0f;

    public virtual void Start()
    {
        if (displayMessage)
        {
            if (uiManager == null)
                uiManager = FindObjectOfType<UIManager>();
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (displayMessage)
            uiManager.StartDisplayInfo(displayInfo, textColor, textFont, fontStyle, fontSize, secondsToClearText);

        if (triggerOnce)
            gameObject.SetActive(false);
    }

    public virtual void DisplayMessage()
    {
        if (displayMessage)
            uiManager.StartDisplayInfo(displayInfo, textColor, textFont, fontStyle, fontSize, secondsToClearText);

        if (triggerOnce)
            gameObject.SetActive(false);
    }
}
