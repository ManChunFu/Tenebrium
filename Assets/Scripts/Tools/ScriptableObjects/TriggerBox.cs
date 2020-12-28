using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor;


public class TriggerBox : MonoBehaviour
{
    public UnityEvent eventTest;

    [SerializeField] private int[] triggerLayers; 
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < triggerLayers.Length; i++)
        {
            if (other.transform.gameObject.layer == triggerLayers[i])
            {
                eventTest?.Invoke();
                
            }
        }
        
    }
    //[MenuItem("Examples/Create Prefab")]
    //void CreateStuff()
    //{

    //}
}
