using System;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleButtonMaster : MonoBehaviour
{
    public UnityEvent onComplete;
    public UnityEvent onFail;
    [SerializeField] PuzzleButton[] connectedButtons;
    public event Action onButtonPressed;
    bool isSolved = false;

    private void Awake()
    {
        foreach (PuzzleButton button in connectedButtons)
        {
            button.OnSolved += CheckButtons;
        }
    }
    void hello()
    {
        onButtonPressed?.Invoke();
    }
    void CheckButtons()
    {
       
        if (!isSolved)
        {
            hello();
            for (int i = 0; i < connectedButtons.Length; i++)
            {
                if (!connectedButtons[i].solved)
                {
                    return;
                }
            }
            CompletePuzzle();
        }
       

    }

    public void CompletePuzzle()
    {
       
        onComplete?.Invoke();

        foreach (PuzzleButton button in connectedButtons)
        {
            
            button.OnPuzzleComplete();
        }
        isSolved = true;
    }
    public void FailPuzzle()
    {
        
        onFail?.Invoke();
        isSolved = true;
    }
}
