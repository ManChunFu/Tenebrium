using UnityEngine;
using System;
//[RequireComponent(typeof(Rigidbody))]
//public class PhysicsItem : MonoBehaviour,IInteractable
//{
//    [HideInInspector]public PlayerInteractable tempParent;
//    public Rigidbody rb;
   
    

//    public virtual void Activate(PlayerInteractable player)
//    {
//        if (player.holdingItem != null)
//        {
//            player.DropItem();
//        }
//      //  player.PickUpItem(this);
//        tempParent = player;


//    }
//    public void DropOverride()
//    {
//        if (tempParent !=null)
//        {
//            tempParent.DropItem();
//        }   
//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//        AkSoundEngine.SetRTPCValue("Force", collision.relativeVelocity.magnitude, gameObject);
//        SoundManager.Sound.SFX.CollisionPorsline.Post(gameObject);
//        Debug.Log(collision.relativeVelocity.magnitude);
//    }

//}
