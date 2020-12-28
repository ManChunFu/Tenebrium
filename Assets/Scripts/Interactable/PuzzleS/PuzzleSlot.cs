using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleSlot : MonoBehaviour,IInteractable
{
    [SerializeField] string compatiblePuzzleItem;
    UnityEvent OnSolvedPuzzle;
    
    public void Activate(PlayerInteractable player)
    {
        //if (player.inventory.ItemDictionary.ContainsKey(compatiblePuzzleItem))
        //{
        //    SolvedPuzzle();
        //}
    }
    
    private void SolvedPuzzle()
    {
        OnSolvedPuzzle?.Invoke();
    }



}
