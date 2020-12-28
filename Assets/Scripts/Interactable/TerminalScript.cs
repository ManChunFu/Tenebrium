using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject Buttons1, Buttons2, Buttons3;
    public GameObject Prefabs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(PlayerInteractable player)
    {
        if (gameObject.GetComponentInChildren<TerminalScript>().Buttons1)
        {
            
            Instantiate(Prefabs, transform.position, transform.rotation);
            Destroy(Buttons2);
        }

    }
    

}
