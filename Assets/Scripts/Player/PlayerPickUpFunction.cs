using System.Collections;
using UnityEngine;

public class PlayerPickUpFunction : MonoBehaviour
{
    public GameObject pickUpAttachmentPoint;
    public PlayerInteractable player;
    [HideInInspector] public PickUpItem holdingItem = null;
    public Animator anim;
    public GameObject head;

    RightHandStates state = RightHandStates.free;

    public bool debugHoldingPos = false;

    PickUpItem cachedItem = null; 
    private void Start()
    {
        player.altKeyUpFunction += DropItem;
    }
    
    public void StartPickUp(PickUpItem item)
    {
        if (item != null)
        {
            cachedItem = item;
            AnimStateSwitch(RightHandStates.pickingUp);
        }
    }
    public void PickUpItem()
    {
        if (cachedItem != null)
        {
            SoundManager.Sound.SFX.Pickup.Post(this.gameObject);
            holdingItem = cachedItem;
            cachedItem = null;


            holdingItem.transform.rotation = pickUpAttachmentPoint.transform.rotation * holdingItem.AdjustRotation; // Rotation needs to go before location since i dont want to account for any off pivots
            holdingItem.transform.position = pickUpAttachmentPoint.transform.position +
           ((pickUpAttachmentPoint.transform.position + holdingItem.transform.position) - (pickUpAttachmentPoint.transform.position + holdingItem.AdjustVector));

            holdingItem.transform.SetParent(pickUpAttachmentPoint.transform);
            if (holdingItem.rb != null)
            {
                holdingItem.rb.isKinematic = true;
            }
            if (holdingItem.collider != null)
            {
                holdingItem.collider.enabled = false;
            }


            if (holdingItem == null)
            {
                anim.SetTrigger("startDrop");
                AnimStateSwitch(RightHandStates.free);
            }
            else
            {
                AnimStateSwitch(RightHandStates.holding);
            }
           
        }
        
    }

    public void DropItem()
    {
        if (holdingItem != null)
        {
            Debug.Log("Dropping");
            AnimStateSwitch(RightHandStates.dropping);
            ThrowItem(0.25f);
        }
    }
    public void ThrowItem(float setForce)
    {
        if (holdingItem != null)
        {
            holdingItem.transform.SetParent(null);
            if (holdingItem.rb != null)
            {
                holdingItem.rb.isKinematic = false;
                holdingItem.rb.AddForce(head.transform.forward * setForce, ForceMode.Impulse);
            }
            if (holdingItem.collider != null)
            {
                holdingItem.collider.enabled = true;
            }
            holdingItem.OnDrop();
            //  holdingItem.tempParent = null;
            holdingItem = null;
            AnimStateSwitch(RightHandStates.free);
        }
        else
        {
            AnimStateSwitch(RightHandStates.free);
        }
    }
    public void ThrowItem() // function to be called from animator
    {
        holdingItem.transform.SetParent(null);      
        if (holdingItem.rb != null)
        {
            holdingItem.rb.isKinematic = false;
            holdingItem.rb.AddForce(head.transform.forward * finalForce, ForceMode.Impulse);
        }
        if (holdingItem.collider != null)
        {
            holdingItem.collider.enabled = true;
        }
        holdingItem.OnDrop();
      //  holdingItem.tempParent = null;
        holdingItem = null;
        
        finalForce = 0;
        AnimStateSwitch(RightHandStates.free);
    }



    bool newThrow = true;
    float force = 0;
    [SerializeField] float minForce = 1f;
    [SerializeField] float maxForce = 15;
    [SerializeField] float forceAdddSpeed = 10;
    
    public void Charging()
    {

        force += Time.deltaTime * forceAdddSpeed;
        if (newThrow && force > minForce)
        {         
            AnimStateSwitch(RightHandStates.charging);           
            newThrow = false;
        }
    }

    public void OnKeyRelease()
    {
        Debug.Log(force);
        if (force > minForce)
        {
            if (force > maxForce)
            {
                StartThrow(maxForce);

            }
            else
            {
                StartThrow(force);

            }
        }
        else
        {
            AnimStateSwitch(RightHandStates.holding);
            DropItem();
            force = 0;
            newThrow = true;
        }
    }
    
    [SerializeField] float finalForce;
    public void StartThrow(float forceToApply)
    {
        newThrow = true;
        finalForce = forceToApply;
        force = 0;
        AnimStateSwitch(RightHandStates.throwin);
    }




    void AnimStateSwitch(RightHandStates newState)
    {
        state = newState;
        switch (state)
        {
            case RightHandStates.holding:
               
                break;
            case RightHandStates.throwin:
                anim.SetTrigger("startThrow");
                break;
            case RightHandStates.charging:
                anim.SetTrigger("startCharge");
                break;
            case RightHandStates.free:
                anim.ResetTrigger("startDrop");
                anim.ResetTrigger("startThrow");
                anim.ResetTrigger("startPickup");
                break;
            case RightHandStates.pickingUp:
                anim.SetTrigger("startPickup");
                break;
            case RightHandStates.dropping:
                anim.SetTrigger("startDrop");

                break;
            default:
                break;
        }
    }

}
