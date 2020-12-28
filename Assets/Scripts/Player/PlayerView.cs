using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]Transform playerBody = null;
    [Range(0.1f, 2.5f)]
    [SerializeField] private float mouseSensitivity = 1.0f;
    [Tooltip("MinVerticalAngle = look up. Prevent vertical rotation go around, max value can not be smaller than min value")]
    [Range(-89f, 89f)]
    [SerializeField] private float minVerticalAngle = -60.0f;
    [Tooltip(" MaxVerticalAngle = look down. Prevent vertical rotation go around, max value can not be smaller than min value")]
    [Range(-89f, 89f)]
    [SerializeField] private float maxVerticalAngle = 60.0f;


    private const string TURN_LEFT_RIGHT = "Mouse X";
    private const string LOOK_UP_DOWN = "Mouse Y";

    private float verticalRotation = 0.0f;
    private void OnValidate()
    {
        if (maxVerticalAngle < minVerticalAngle)
            maxVerticalAngle = minVerticalAngle; 
    }

    private void Awake()
    {
        if (playerBody == null)
            throw new MissingReferenceException("Missing Transform reference of Player");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        float lookX = Input.GetAxis(TURN_LEFT_RIGHT) * mouseSensitivity;
        float lookY = Input.GetAxis(LOOK_UP_DOWN) * mouseSensitivity;

        verticalRotation -= lookY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        playerBody.Rotate(Vector3.up * lookX);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);
    }
}
