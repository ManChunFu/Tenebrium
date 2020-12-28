using System.Collections;
using System;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    
    public bool solved = false;
   
    public event Action OnSolved;
    public bool canChangeMode = true; // I hate this bool. It is bad. But its the only way to prevent a delayed coroutine.
    Coroutine co;
    [SerializeField] ButtonTriggerGeneral button;

    [SerializeField] float timeUntilFail = 1;
    
    public void Activate()
    {
        solved = true;
        OnSolved?.Invoke();
        button.SetToIsPressed();
        co = StartCoroutine(InternalTimer());
    }

    IEnumerator InternalTimer()
    {    
        yield return new WaitForSeconds(timeUntilFail);
        solved = false;
        co = null;
        if (canChangeMode)
        {
            button.SetToActive();
        }
    }

    public void SetActivePerm()
    {
        solved = true;
        
        button.SetToIsPressed();
        canChangeMode = false;
    }
    public void OnPuzzleComplete()
    {
        canChangeMode = false;
        button.SetToIsPressed();
    }

}
