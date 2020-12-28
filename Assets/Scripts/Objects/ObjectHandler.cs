using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour, IObjectHandler
{
    public Transform spawnpoint;
    public void DoSomething(GameObject item)
    {
        item.transform.position = spawnpoint.position;
    }
}
