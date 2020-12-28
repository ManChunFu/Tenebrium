using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector]public Dictionary<string, PuzzleItem> ItemDictionary { get; private set; } = new Dictionary<string, PuzzleItem>(); 

    public void AddItem(string name, PuzzleItem item)
    {
        ItemDictionary.Add(name, item);
    }
}
