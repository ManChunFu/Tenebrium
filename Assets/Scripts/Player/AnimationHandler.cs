using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private GameObject leftFootObject;
    [SerializeField] private GameObject rightFootObject;
    [SerializeField] private PlayerPickUpFunction pickupFunction;
    [SerializeField] private PlayerPressButtonFunction pressButtonFunction;

    private Animator anim = null;
    private int startDropID = Animator.StringToHash("startDrop");
    private int startThrowID = Animator.StringToHash("startThrow");
    private int startPickupID = Animator.StringToHash("startPickup");
    private int isEmptyID = Animator.StringToHash("isEmpty");
    private int endThrowID = Animator.StringToHash("endThrow");
    private int endPickupID = Animator.StringToHash("endPickup");
    private int endPokeID = Animator.StringToHash("endPoke");
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayRightFoot()
    {
        SoundManager.Sound.SFX.FootstepRight.Post(rightFootObject);
    }

    public void PlayLeftFoot()
    {
        SoundManager.Sound.SFX.FootstepLeft.Post(leftFootObject);
    }

    private void endPickup()
    {
        anim.SetTrigger(endPickupID);
    }

    private void endThrow()
    {
        anim.SetTrigger(endThrowID);
    }

    private void SendSignalPickUpItem()
    {
        pickupFunction.PickUpItem();
    }

    private void SendSignalThrowItem()
    {
        pickupFunction.ThrowItem();
    }

    private void SendSignalTriggerButton()
    {
        pressButtonFunction.PressButton();
    }

    private void endPoke()
    {
        anim.SetTrigger(endPokeID);
    }

    private void CheckIfItemIsCarried()
    {
        if (pickupFunction.holdingItem == null)
        {
            anim.ResetTrigger(startDropID);
            anim.ResetTrigger(startThrowID);
            anim.ResetTrigger(startPickupID);
            anim.SetTrigger(isEmptyID);

        }

    }
}
