using SpaceGame.Dog;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RoomBellTriggerBox : LocationSharing
{
    [SerializeField] private DogAgent dogAgent = null;
    private BoxCollider boxCollider;

    private void Start()
    {
        if (dogAgent == null)
            dogAgent = FindObjectOfType<DogAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dogAgent.CallDogToFollow();
            locationData.UpdateCharacterLocation(other.tag, roomNo);
        }
        else if (other.CompareTag("Dog"))
        {
            locationData.UpdateCharacterLocation(other.tag, roomNo);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        boxCollider = GetComponent<BoxCollider>();
        Gizmos.DrawWireCube(transform.position, transform.TransformDirection(boxCollider.size));
    }
}
