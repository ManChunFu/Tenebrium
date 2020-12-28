using UnityEngine;

public class DoorDetactionCollision : MonoBehaviour
{
    [SerializeField] private Door door = null;
    public bool isPlayerBlockingWay { get; private set; }

    private void Start()
    {
        if (door == null)
            door = transform.GetComponentInChildren<Door>();
    }

    private void OnTriggerStay(Collider other)
    {
        isPlayerBlockingWay = true;
        if (door.IsOpening)
            return;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerBlockingWay = false;

        if (door.IsOpening)
            return;

        if (door.IsInterpted)
        {
            if (!door.IsClosing)
               door.CloseDoor();
        }
    }
}
