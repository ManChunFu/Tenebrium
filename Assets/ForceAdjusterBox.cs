using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ForceAdjusterBox : MonoBehaviour
{
    

    public List<Rigidbody> rigibodyList;   
     BoxCollider box;
    [SerializeField] bool continuousUpdate;
    [SerializeField] int layerToAdd =14;
    [SerializeField] float forceToAdd = 1.1f;
    [SerializeField] float torqueToAdd = 0.5f;

    [SerializeField] Vector3 forceDirection = new Vector3(0,0.7f,0);

    [SerializeField] float forceRandNrAdjuster = 0.5f;
    [SerializeField] float torqueRandNrAdjuster = 0.2f;
    [SerializeField] float vecXRandNRAdjuster = 0.5f;
    [SerializeField] float vecYRandNRAdjuster = 0.5f;
    [SerializeField] float vecZRandNRAdjuster = 0.5f;

    public bool doOnce = true;
    bool executed = false;
    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        box.isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Start()
    {
        if (!continuousUpdate)
        {
            StartCoroutine(Initialize());
        }
        
    }

    IEnumerator Initialize()
    {
        yield return new WaitForEndOfFrame();
        box.enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerToAdd)
        {
            if (other.gameObject.GetComponent<Rigidbody>())
            {
                rigibodyList.Add(other.gameObject.GetComponent<Rigidbody>());
            }
        }
    }


    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layerToAdd)
        {
            if (rigibodyList.Contains(other.gameObject.GetComponent<Rigidbody>()))
            {

            }
        }    
    }

  
   

    public void DoImpulse()
    {
        if (doOnce)
        {
            if (!executed)
            {
                StartCoroutine(DoingImpulse());
                executed = true;
            }
        }
        else
        {
            StartCoroutine(DoingImpulse());
        }
       
    }
    IEnumerator DoingImpulse()
    {
        
        foreach (Rigidbody rb in rigibodyList)
        {
            Vector3 tempVec;
            tempVec.x = Random.Range(forceDirection.x - vecXRandNRAdjuster, forceDirection.x + vecXRandNRAdjuster);
            tempVec.y = Random.Range(forceDirection.y - vecYRandNRAdjuster, forceDirection.y + vecYRandNRAdjuster);
            tempVec.z = Random.Range(forceDirection.z - vecZRandNRAdjuster, forceDirection.z + vecZRandNRAdjuster);
            rb.AddForce(tempVec * Random.Range(forceToAdd- forceRandNrAdjuster, forceToAdd + forceRandNrAdjuster), ForceMode.Impulse);
            rb.AddTorque(tempVec * Random.Range(torqueToAdd - torqueRandNrAdjuster, torqueToAdd + torqueRandNrAdjuster), ForceMode.Impulse);
        }       
        yield return null;
    }


    public void TurnOffBox()
    {
        box.enabled = false;
    }
    public void TurnOnBox()
    {
        box.enabled = true;
    }

}
