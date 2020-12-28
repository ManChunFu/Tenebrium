using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectFromParent : MonoBehaviour
{

    public void RemoveFromParent()
    {
        transform.parent = null;
    }
}
