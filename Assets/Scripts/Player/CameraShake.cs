using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;

    private float time = 0.0f;
    private float lastFieldOfView, nextFieldOfView = 0.0f;
   

    private void Awake()
    {
        if (playerCamera == null)
            playerCamera = GetComponent<Camera>();

        if (playerCamera != null)
            playerCamera.enabled = false;
    }

    public void StartCameraShake(float shakeDuration, float shakeForce, Vector3 shakeRange, AnimationCurve curve)
    {
        StartCoroutine(Shake(shakeDuration, shakeForce, shakeRange, curve));
    }

    private IEnumerator Shake(float shakeDuration, float shakeForce, Vector3 shakeRange, AnimationCurve curve)
    {
        time = shakeDuration;
        Vector3 originPos = transform.localPosition;
        Vector3 lastPosition, nextPosition = Vector3.zero;

        while (time > 0)
        {
            lastPosition = nextPosition;
            lastFieldOfView = nextFieldOfView;

            time -= Time.deltaTime;

            // Use PerlinNoise to perform a smooth movement.
            // Multiple 1.5f to make x and y  have different outputs.
            // Output is a random number betweeen 0 and 1, so substract 1/2 so we get value between -0.5f and 0.5f.
            // Multiple shakeForce as an accelerator for the time
            // curve is between 0 and 1, passing 1f - time/shakeDuration as paramater to make it start from 0 and end at 1
            nextPosition = (Mathf.PerlinNoise(time * shakeForce, time * 1.5f) - 0.5f) * shakeRange.x * transform.right * curve.Evaluate(1f - time / shakeDuration) +
                           (Mathf.PerlinNoise(time * shakeForce * 1.5f, time) - 0.5f ) * shakeRange.y * transform.up * curve.Evaluate(1f - time / shakeDuration);
            nextFieldOfView = (Mathf.PerlinNoise(time * shakeForce * 1.5f, time * 2) - 0.5f) * shakeRange.z * curve.Evaluate(1f - time / shakeDuration);
            playerCamera.fieldOfView += (nextFieldOfView - lastFieldOfView);
            playerCamera.transform.Translate(nextPosition - lastPosition);
            
            yield return null;
        }
        playerCamera.transform.localPosition = originPos;
    }
}
