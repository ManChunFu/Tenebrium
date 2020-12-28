using SpaceGame.Dog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrigger : MonoBehaviour
{
    public PuzzleButton button;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            button.SetActivePerm();
            Debug.Log("Activated");
        }
    }
}
