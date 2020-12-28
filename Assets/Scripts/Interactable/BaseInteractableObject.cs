using System;
using UnityEngine;

public abstract class BaseInteractableObject : MonoBehaviour
{
    public event Action OnActivate;
    public virtual void Use()
    {

    }
}
