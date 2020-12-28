using System;
using UnityEngine;

public class PlayerRayTrace : MonoBehaviour
{
    [SerializeField] private Transform traceStartPosition;
    [SerializeField] private float distance = 5f;

    public event Action<RaycastHit> rayCastHit;

    public event Action<RaycastHit> onUseKeyPressed;
    public event Action<RaycastHit> onUseKeyReleased;
    public event Action itemUseKeyPressed;
    public event Action itemUseKeyReleased;

    public LayerMask layers;
    private void Awake()
    {
        
    }

    private void Update()
    {
        RaycastHit hellothere;
        
        if (Physics.Raycast(traceStartPosition.position, traceStartPosition.transform.forward, out hellothere, distance, layers)) { }            
        if (Input.GetButton("Use"))
        {
            onUseKeyPressed?.Invoke(hellothere);
            
        }
        if (Input.GetButtonUp("Use"))
        {
            onUseKeyReleased?.Invoke(hellothere);
        }
        


        if (Input.GetButton("Throw"))
        {
            itemUseKeyPressed?.Invoke();
            
        }
        if (Input.GetButtonUp("Throw"))
        {
            itemUseKeyReleased?.Invoke();
        }

        rayCastHit?.Invoke(hellothere);
    }

}
       
    


 






