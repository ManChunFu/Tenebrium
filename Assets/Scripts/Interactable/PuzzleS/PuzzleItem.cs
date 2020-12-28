using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    public void Activate(PlayerInteractable player)
    {
        //player.inventory.AddItem(itemName, this);
        this.gameObject.SetActive(false);
    }
    

}
