using UnityEngine;
using UnityEngine.Events;
using System;
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public SpawnableItem itemToSpawn;
    [SerializeField] int limit;
    [SerializeField] bool spawnLimit;
    public GameObject objectHandler;

    public UnityEvent onHitSpawnLimit;

    private IObjectHandler correctType;

    private void Awake()
    {
        SetCorrectType();
    }

    void SetCorrectType()
    {
        if (objectHandler != null)
        {
            correctType = objectHandler.GetComponent<IObjectHandler>();
        }
       
    }
   public void SpawnItem()
    {
        if (spawnLimit && limit > 0)
        {
           
            if (itemToSpawn.pool == null)
            {
                itemToSpawn.InstantiatePool();

            }
            GiveObjectToHandler(itemToSpawn.pool.GetUnit(true));
            limit--;
            if (limit <= 0)
            {
                onHitSpawnLimit?.Invoke();
            }
        }
        else if(!spawnLimit)
        {
            if (itemToSpawn.pool == null)
            {
                itemToSpawn.InstantiatePool();

            }

            GiveObjectToHandler(itemToSpawn.pool.GetUnit(true));
        }

        
    }


    void GiveObjectToHandler(GameObject spawnedObject)
    {
        
        if (objectHandler != null)
        {
            correctType.DoSomething(spawnedObject);
        }
        else
        {
            Debug.Log("No Handler Referenced");
            spawnedObject.transform.position = transform.position;
        }
    }
}

