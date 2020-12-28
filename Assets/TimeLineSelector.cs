
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider))]
public class TimeLineSelector : MonoBehaviour
{
    public bool selector;
    public UnityEvent selectorTrue;
    public UnityEvent selectorFalse;

    public int layerToTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerToTrigger)
        {
            TriggerEvent();
        } 
    }

    public void TriggerEvent()
    {
        if (selector)
        {
            selectorTrue?.Invoke();
        }
        else
        {
            selectorFalse?.Invoke();
        }

    }
    public void SetSelectorTrue()
    {
        selector = true;
    }
    public void SetSelectorFalse()
    {
        selector = false;
    }
}
