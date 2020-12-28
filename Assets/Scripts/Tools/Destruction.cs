using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{

    public float RepsSize = 0.2f;
    public int RepsRows = 4;

    public GameObject explodeBits = null;

    float RepsPivDist;
    Vector3 RepsPiv;

    public float ExplosionForce = 50f;
    public float ExplosionRadius = 4f;
    public float ExplosionUpward = 0.4f;

    private void Start()
    {
        RepsPivDist = RepsSize * RepsRows / 2;
        RepsPiv = new Vector3(RepsPivDist, RepsPivDist, RepsPivDist);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Floor") //Alan....Please change this /L.
        {
            Explode();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;

        }
            this.GetComponent<Collider>().enabled = false;
        
    }


    public void Explode()
    {
        gameObject.GetComponent<Renderer>().enabled = false;

        for (int x = 0; x < RepsRows; x++)
        {
            for (int y = 0; y < RepsRows; y++)
            {
                for (int z = 0; z < RepsRows; z++)
                {
                    CreateReps(x,y,z);
                }
            }
        }

        Vector3 ExplosionPos = transform.localPosition;
        
        Collider[] colliders = Physics.OverlapSphere(ExplosionPos, ExplosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rgb = hit.GetComponent<Rigidbody>();
            if (rgb != null)
            {
                rgb.AddExplosionForce(ExplosionForce, transform.localPosition, ExplosionRadius, ExplosionUpward);
                
            }
        }
        
        
    }

    private void CreateReps(float x, float y, float z)
    {
        GameObject Reps;
        Reps = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Reps.transform.SetParent(transform);
        Reps.transform.localPosition = new Vector3(RepsSize * x, RepsSize * y, RepsSize * z) - RepsPiv;
        //Reps.transform.rotation = transform.rotation * Quaternion.Euler(RepsSize * z, RepsSize * x, RepsSize * y);
        Reps.transform.localScale = new Vector3(RepsSize, RepsSize, RepsSize);

        Reps.AddComponent<Rigidbody>();
        Reps.GetComponent<Rigidbody>().mass = RepsSize;
        Reps.GetComponent<Rigidbody>().useGravity = false;


    }

    

}
