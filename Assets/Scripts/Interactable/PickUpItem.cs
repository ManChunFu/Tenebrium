using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    [HideInInspector] public PlayerPickUpFunction tempParent;
    
    public Rigidbody rb = null;
    public Collider collider = null;
    public event Action pickedUp;
    public event Action dropped;
    public GameObject attatchmentPoint = null;
    public bool debug = false;
    public Vector3 AdjustVector
    {
        get
        {
            if (attatchmentPoint != null)
            {
                
                return attatchmentPoint.transform.position;
            }
            else
            {
                return transform.position;
            }
        }
        private set { }
    }
    public Quaternion AdjustRotation
    {
        get
        {
            if (attatchmentPoint != null)
            {
               
                return attatchmentPoint.transform.localRotation;
            }
            else
            {
                return transform.rotation;
            }
        } 
        private set { } 
    }

    



    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            
        }
        if (collider == null)
        {
            collider = GetComponent<Collider>();
        }

        

       Interaction interact = transform.GetComponent<Interaction>();
        if (interact != null && !interact.customSetup)
        {
            interact.ExternalSetup(this, true);
        }
    }
    public void SetRotation()
    {
        transform.rotation = attatchmentPoint.transform.localRotation;
        Debug.Log(attatchmentPoint.transform.localRotation);
        Debug.Log(transform.rotation);

    }
  

    public virtual void Activate(PlayerInteractable player)
    {
        if (player.pickUpFunction.holdingItem != null)
        {
            player.pickUpFunction.DropItem();
            Debug.Log("Dropping");
        }
        pickedUp?.Invoke();
        player.pickUpFunction.StartPickUp(this);
        tempParent = player.pickUpFunction;
    }
    public void OnDrop()
    {
        dropped?.Invoke();
    }
    public void DropOverride()
    {
        if (tempParent != null)
        {
            tempParent.ThrowItem();
        }
    }
    

}
