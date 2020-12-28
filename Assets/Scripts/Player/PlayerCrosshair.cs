using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] private Sprite unClickSprite = null;
    [SerializeField] private Sprite onClickSprite = null;
    [SerializeField] private Sprite crosshairHover;
    [SerializeField] private Image crosshair;

    [SerializeField] PlayerRayTrace rayCast;

   

    bool canChangeSprite = true;

    private void Awake()
    {
        rayCast.rayCastHit += hello;
        rayCast.onUseKeyPressed += onUsekey;


    }

    IEnumerator TimerStuff()
    {
        canChangeSprite = false;
        yield return new WaitForSeconds(0.5f);
        canChangeSprite = true;


    }

    void hello(RaycastHit hit)
    {    
        if (canChangeSprite)
        {                     
            if (hit.transform != null)
            {
                if (hit.transform.GetComponent<IInteractable>() != null)
                {
                    CrosshairHovering();
                }
                else
                {
                    CrosshairNormal();
                }
            }
            else
            {
                CrosshairNormal();
            }
        }

    }
    void onUsekey(RaycastHit hit)
    {
        
            CrosshairOnClick();
            StartCoroutine(TimerStuff());
        
    }
    public void CrosshairHovering()
    {
       
        crosshair.sprite = crosshairHover;
    }

    public void CrosshairOnClick()
    {
        crosshair.sprite = onClickSprite;
    }

    public void CrosshairNormal()
    {
        
        crosshair.sprite = unClickSprite;
    }
}
