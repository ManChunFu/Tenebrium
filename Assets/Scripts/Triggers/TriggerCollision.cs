using UnityEngine;
using UnityEngine.Events;

public class TriggerCollision : TriggerDisplayUIBase
{
    [SerializeField]  UnityEvent onTriggerActivate = null;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
        }
        
        base.OnTriggerEnter(other);
    }
    public void Activate()
    {
        onTriggerActivate?.Invoke();
    }
}
