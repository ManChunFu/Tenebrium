using UnityEngine;
using UnityEngine.UI;

public class CrosshairAction : MonoBehaviour
{
    [SerializeField] private Sprite unClickSprite = null;
    [SerializeField] private Sprite onClickSprite = null;

    public PlayerInventory inventory;

    private Image crosshair = null;
    private void Awake()
    {
        crosshair = GetComponent<Image>();

        if (unClickSprite == null)
            throw new MissingReferenceException("Missing reference of Crosshair sprite for UnClick function");

        if (onClickSprite == null)
            throw new MissingReferenceException("Missing reference of Crosshair sprite for OnClick function");
    }

    private void Start()
    {
        if (unClickSprite != null)
            crosshair.sprite = unClickSprite;
    }

    private void Update()
    {
       
        var ray = Camera.main.ScreenPointToRay(crosshair.transform.position);

        if (Input.GetKeyDown(KeyCode.E) && crosshair.sprite != onClickSprite)
        {
            Debug.Log("Drawing");
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IInteractable iTarget = hit.transform.GetComponent<IInteractable>();
                if (iTarget != null)
                {
                    Debug.Log("Hit");
                    crosshair.sprite = onClickSprite;
                    
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && crosshair.sprite != unClickSprite)
        {
            crosshair.sprite = unClickSprite;
        }
    }
}

