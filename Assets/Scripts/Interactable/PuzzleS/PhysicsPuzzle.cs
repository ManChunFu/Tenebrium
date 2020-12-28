using System;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsPuzzle : MonoBehaviour
{
    [Serializable]
    public struct test
    {
        [SerializeField] int onSlotsSolved;
        public UnityEvent effect;      
        bool executedOnce;     
        void DoEvent()
        {
            effect?.Invoke();
        }

        public void Check(int i)
        {      
            if (i == onSlotsSolved && !executedOnce)
            {
                DoEvent();
                executedOnce = true;
            }
        }
    }


    event Action<int> onNrUpdate;

    public UnityEvent OnSolved;
    public UnityEvent OnFailed;
    public test[] partEvents;
    public PhysicsPuzzleSlot[] slots;
    

    [SerializeField] bool puzzleIsActive = true;
    private void Awake()
    {
        for (int i = 0; i < partEvents.Length; i++)
        {
            onNrUpdate += partEvents[i].Check;
        }
    }
    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].OnSolved += CheckIfSolved;
            slots[i].SlotSetActive(puzzleIsActive);
        }
       
    }
    void OnPuzzleSolved()
    {
        
        OnSolved?.Invoke();
    }
    public void OnPuzzleFailed()
    {
        OnFailed?.Invoke();
    }
    void CheckIfSolved()
    {
        if (puzzleIsActive)
        {
            int amountSlotsSolved = 0;
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].slotSolved)
                {
                    amountSlotsSolved++;
                }
            }
            if (amountSlotsSolved == slots.Length)
            {
                OnPuzzleSolved();
                return;
            }
            CheckNR(amountSlotsSolved);
        }
        
    }

    void CheckNR(int nr)
    {
        onNrUpdate?.Invoke(nr);       
    }

    public void SetActive()
    {
        puzzleIsActive = true;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SlotSetActive(true);
        }
    }

    public void SetInactive()
    {
        puzzleIsActive = false;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SlotSetActive(false);
        }
    }
    
}
