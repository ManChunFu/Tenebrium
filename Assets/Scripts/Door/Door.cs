using SpaceGame.Dog;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum DoorStatus
{
    Open,
    Close
}
public class Door : MonoBehaviour
{
    [SerializeField] private TeleportDog teleportDog = null;
    [SerializeField] private Vector3 openedDoorPosition = Vector3.zero;
    [SerializeField] private float openDoorSpeed = 0.5f;
    [SerializeField] private bool autoClose = false;
    [SerializeField] private float waitTimeBeforeClose = 3.0f;
    [SerializeField] DoorStatus doorStatus = DoorStatus.Close;
    [SerializeField] private DoorDetactionCollision triggerDoorCollision = null;


    [SerializeField] UnityEvent Moving;
        
    public bool AutoClose => autoClose;
    public bool IsOpening { get; private set; }
    public bool IsClosing { get; private set; }

    public bool IsInterpted { get; private set; }
    public DoorStatus DoorStatus => doorStatus;
    private Vector3 originalPosition = Vector3.zero;
    private Vector3 desiredDoorPosition = Vector3.zero;


    private void Awake()
    {
        originalPosition = transform.position;
        desiredDoorPosition = transform.position + openedDoorPosition;

        // Only work for the door status is open and need to be closed
        if (doorStatus == DoorStatus.Open)
        {
            originalPosition = transform.position + openedDoorPosition;
            desiredDoorPosition = transform.position;
        }
    }

    private void Start()
    {
        if (teleportDog == null)
            teleportDog = FindObjectOfType<TeleportDog>();

        if (triggerDoorCollision == null)
            triggerDoorCollision = transform.GetComponentInParent<DoorDetactionCollision>();
    }

    public void OpenCloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(OpenCloseDoorCoroutine());
    }

    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(CloseDoorCoroutine());
    }

    private IEnumerator OpenCloseDoorCoroutine()
    {
        Moving?.Invoke();
        while (Mathf.Abs(Vector3.Distance(transform.position, desiredDoorPosition)) > 0.1f)
        {
            if (!IsOpening)
            {
                IsOpening = true;
                SoundManager.Sound.SFX.DoorOpen.Post(gameObject);
                IsClosing = false;
            }

            transform.position = Vector3.Lerp(transform.position, desiredDoorPosition, openDoorSpeed * Time.deltaTime);
            yield return null;
        }

        IsOpening = false;
        Moving?.Invoke();

        if (!autoClose)
        {
            teleportDog.TrackPlayerLocation();
            if (IsInterpted && !triggerDoorCollision.isPlayerBlockingWay)
                CloseDoor();
        }
        else if (!triggerDoorCollision.isPlayerBlockingWay)
            CloseDoor();
    }

    private IEnumerator CloseDoorCoroutine()
    {
        Moving?.Invoke();

        if (autoClose)
            yield return new WaitForSeconds(waitTimeBeforeClose);


        while (Vector3.Distance(transform.position, originalPosition) > 0.02f)
        {
            IsInterpted = false;
            if (!IsClosing)
            {
                IsClosing = true;
                SoundManager.Sound.SFX.DoorClose.Post(gameObject);
                IsOpening = false;
            }
            if (triggerDoorCollision.isPlayerBlockingWay)
            {
                IsClosing = false;
                IsInterpted = true;
                OpenCloseDoor();
                yield break;
            }

            transform.position = Vector3.Lerp(transform.position, originalPosition, openDoorSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = originalPosition;
        IsClosing = false;
        Moving?.Invoke();
        teleportDog.TrackPlayerLocation();
    }
}
