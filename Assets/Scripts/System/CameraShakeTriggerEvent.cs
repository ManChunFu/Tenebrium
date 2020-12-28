using UnityEngine;

public class CameraShakeTriggerEvent : TriggerDisplayUIBase
{
    [SerializeField] protected CameraShake cameraShake = null;

    [SerializeField] private float shakeDuration = 1.0f;
    [SerializeField] private float shakeForce = 10.0f;
    [SerializeField] private Vector3 shakeRange = new Vector3(1f, 1f, 0f);
    [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    public override void Start()
    {
        if (cameraShake == null)
            cameraShake = FindObjectOfType<CameraShake>();

        base.Start();
    }
    // For debuging only
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cameraShake.StartCameraShake(shakeDuration, shakeForce, shakeRange, curve);

        base.OnTriggerEnter(other);
    }

    public void CameraShake()
    {
        cameraShake.StartCameraShake(shakeDuration, shakeForce, shakeRange, curve);
        DisplayMessage();
    }

    
}
