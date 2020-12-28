using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{

    public GameObject Fractured;
    

    private void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        
        BreakMe();
        other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        
        this.GetComponent<Collider>().enabled = false;

    }

    public void BreakMe()
    {
        GameObject FracsObj = Instantiate(Fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
