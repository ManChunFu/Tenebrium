using UnityEngine.Events;
using UnityEngine;
using System;


public class PhysicsPuzzleSlot : MonoBehaviour, IInteractable
{
    public UnityEvent WhenSolved;
   
    public event Action OnSolved;
    public int puzzleNR;
    public int partNR;
    [SerializeField] GameObject standInPart;
    public bool slotSolved = false;
    public bool slotActive = true;
    private void Awake()
    {
        if (!slotSolved)
        {
            standInPart.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!slotSolved && slotActive)
        {
            if (other.gameObject.layer == 13)
            {
                Debug.Log("Found Item");
                PhysicsPuzzlePart part = other.gameObject.GetComponent<PhysicsPuzzlePart>();
                if ( part.puzzleNR == puzzleNR && part.partNR == partNR)
                {
                    Debug.Log("Correct Item");
                   // part.DropOverride();
                    part.gameObject.SetActive(false);
                    standInPart.SetActive(true);
                    slotSolved = true;
                    OnSolved?.Invoke();
                    WhenSolved?.Invoke();
                }

            }
        }
        
    }
    public void SlotSetActive(bool active)
    {
        slotActive = active;
    }

    public void MakeSlotActive()
    {
        slotActive = true;
    }
    public void MakeSlotInactive()
    {
        slotActive = false;
    }

    public void Activate(PlayerInteractable player)
    {
        if (!slotSolved && slotActive)
        {
            if (player.pickUpFunction.holdingItem != null)
            {
                Debug.Log("HEllo");
                PhysicsPuzzlePart part = player.pickUpFunction.holdingItem.GetComponent<PhysicsPuzzlePart>();
                if (part.puzzleNR == puzzleNR && part.partNR == partNR)
                {
                    player.pickUpFunction.holdingItem.DropOverride();
                    part.gameObject.SetActive(false);
                    standInPart.SetActive(true);
                    slotSolved = true;
                    OnSolved?.Invoke();
                    WhenSolved?.Invoke();
                }
            }
        }
    }

    public void Test()
    {
        throw new NotImplementedException();
    }
}



