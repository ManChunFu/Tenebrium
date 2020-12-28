using System.Collections.Generic;
using UnityEngine;

public class PhysicsForceAdjuster : MonoBehaviour
{
    public List<Rigidbody> units;

    void DoImpulse()
    {
        foreach (Rigidbody unit in units)
        {
            unit.AddForce(new Vector3(0, 0, 1), ForceMode.Impulse);
        }
    }
}

