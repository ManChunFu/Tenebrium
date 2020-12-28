using UnityEngine;

public class ObjectDeSpawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            other.gameObject.GetComponent<PickUpItem>().DropOverride();
            other.gameObject.SetActive(false);
        }
    }
}
