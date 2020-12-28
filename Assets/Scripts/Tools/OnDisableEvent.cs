using System;
using UnityEngine;

public class OnDisableEvent : MonoBehaviour
{
    public event Action<GameObject> OnDisableObject;

    private void OnDisable()
    {
        OnDisableObject?.Invoke(this.gameObject);
    }
}
