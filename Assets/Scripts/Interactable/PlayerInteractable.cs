using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteractable : MonoBehaviour
{
    public PlayerPickUpFunction pickUpFunction;
    public PlayerPressButtonFunction pressButtonFunction;
    public PlayerRayTrace raycastHit;
    
    
    public event Action altKeyUpFunction; // i know there is on in the raycast lready, but i dont want to make a funtion with a raycast hit intake.

    bool charging;
    float ThrowForce = 0;
    Transform target = null;
    float timer;
    private void Awake()
    {
       
        if (raycastHit == null)
        {
            raycastHit = gameObject.GetComponent<PlayerRayTrace>();
        }
        raycastHit.onUseKeyPressed += Interact;
        raycastHit.onUseKeyReleased += OnKeyReleased;

        raycastHit.itemUseKeyPressed += ItemFunction;
        raycastHit.itemUseKeyReleased += TEstFunction;
    }

    // it is 3 am, i dont know what i am doing anymore. My only whish is that a meteor would hit earth so that i dont have to deal with this shit anymore.... 
    void Interact(RaycastHit hit)
    {
        
        if (hit.transform != null )
        {
            if (target != null && hit.transform == target)
            {
                SameTarget();
            }
            else
            {
                NewTarget(hit);
            }
        }
        else
        {
            if (target == null || timer > 0)
            {
                ResetSaved();
            }
        }
    }
    void SameTarget()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
           
            ExecuteSecondaryFunction(target.GetComponent<Interaction>());
            ResetSaved();
        }
    }
    void NewTarget(RaycastHit hit)
    {
        Interaction iTarget = hit.transform.GetComponent<Interaction>();
        if (iTarget != null)
        {
            //if (iTarget.hasSecondary)
            //{

            //}
            target = iTarget.transform;
        }
    }
    void OnKeyReleased(RaycastHit hit)
    {
        if (timer < 1.5f)
        {

           
            if (target != null)
            {
                Interaction iTarget = target.GetComponent<Interaction>();
                if (iTarget != null)
                {
                    
                    ExecuteMainFunction(iTarget);
                    ResetSaved();
                }
                else
                {
                    altKeyUpFunction?.Invoke();
                    ResetSaved();
                }
                
            }
            else
            {
                altKeyUpFunction?.Invoke();
                ResetSaved();
            }
        }
    }
    void ResetSaved()
    {
        target = null;
        timer = 0;
    }
    void ExecuteMainFunction(Interaction iTarget)
    {
        //anim.SetTrigger("startPoke");
        iTarget.DoMainFunction(this);
    }
    void ExecuteSecondaryFunction(Interaction iTarget)
    {
        //anim.SetTrigger("startPoke");
        iTarget.DoSecondaryFunction(this);
    }

    // Fuck modularity lets just get this bitch done!!!!!!!
    void ItemFunction()
    {
        if (pickUpFunction.holdingItem != null)
        {
            pickUpFunction.Charging();
            Debug.Log("cHARGING tHROW");    
        }
    }

    void TEstFunction()
    {
        pickUpFunction.OnKeyRelease();
    }






}
