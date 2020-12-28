using System.Collections;
using UnityEngine;

public class CameraBlurRotation : MonoBehaviour
{
    [SerializeField] private Camera headCamera = null;
    [SerializeField] private GameObject blink = null;
    [Header("BlurRotationFunctionSetting")]
    [SerializeField] private float leftRotation = -10.0f;
    [SerializeField] private float leftRotateSpeed = 0.05f;
    [SerializeField] private float rightRotation = 5.0f;
    [SerializeField] private float rightRotateSpeed = 0.06f;
    [SerializeField] private float rotateBackSpeed = 0.07f;
    [Header("BlurFunctionSetting")]
    [SerializeField] private float blurDuration = 4.0f;
    [SerializeField, Range(0f, 0.2f)] private float blurMaxRadius = 0.2f;
    [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 0);
    [SerializeField] private CameraBlurEffect camBlurEffect = null;
   
    private Quaternion originRotation = default;
    private float originFOV = 75.0f;
    private int blurRadius = Shader.PropertyToID("_Radius");

    private PlayerController playerController = null;

    private void Awake()
    {
        if (headCamera == null)
            headCamera = transform.GetChild(0)?.GetComponent<Camera>();

        if (headCamera != null)
            originFOV = headCamera.fieldOfView;

        originRotation = transform.localRotation;

        if (camBlurEffect == null)
            camBlurEffect = transform.GetChild(0).GetComponent<CameraBlurEffect>();

        playerController = transform.parent.GetComponent<PlayerController>();
    }

    private void Start()
    {
        if (blink == null)
            blink = FindObjectOfType<Canvas>()?.transform.GetChild(2).gameObject;

        if (blink.activeSelf)
            blink.SetActive(false);
    }

    public void SetBlurVision(bool autoDisable)
    {
        StartCoroutine(BlurVisionCoroutine(autoDisable));
    }

    private IEnumerator BlurVisionCoroutine(bool autoDisable)
    {
        camBlurEffect.enabled = true;
        float time = blurDuration;
        while (time > 0)
        {
            time -= Time.deltaTime;
            float value = blurMaxRadius * curve.Evaluate(1f - time / blurDuration);
            camBlurEffect.ShaderEfx.SetFloat(blurRadius, value);
            yield return null;
        }

        if (autoDisable)
            camBlurEffect.enabled = false;
    }


    public void StartBlurryRotation()
    {
        StartCoroutine(StartBlurryRotationCoroutine());
    }

    private IEnumerator StartBlurryRotationCoroutine()
    {
        camBlurEffect.enabled = true;
        camBlurEffect.ShaderEfx.SetFloat(blurRadius, blurMaxRadius);
        blink.SetActive(true);

        playerController.SetMoveSpeed(0.5f);

        for (float degree = 0, distance = originFOV; degree > leftRotation; degree -= 0.1f, distance += 0.2f)
        {
            transform.localRotation = Quaternion.Euler(originRotation.x, originRotation.y, degree);
            headCamera.fieldOfView = distance;
            camBlurEffect.ShaderEfx.SetFloat(blurRadius, blurMaxRadius -= 0.001f);
            yield return new WaitForSeconds(leftRotateSpeed);
        }

        playerController.SetMoveSpeed(1f);

        for (float degree = leftRotation, distance = headCamera.fieldOfView; degree < rightRotation; degree += 0.1f, distance -= 0.05f)
        {
            transform.localRotation = Quaternion.Euler(originRotation.x, originRotation.y, degree);
            headCamera.fieldOfView = distance;
            camBlurEffect.ShaderEfx.SetFloat(blurRadius, blurMaxRadius -= 0.001f);
            yield return new WaitForSeconds(rightRotateSpeed);
        }

        playerController.SetMoveSpeed(1.5f);

        for (float degree = rightRotation, distance = headCamera.fieldOfView; degree >= 0f; degree -= 0.05f, distance -= 0.1f)
        {
            transform.localRotation = Quaternion.Euler(originRotation.x, originRotation.y, degree);
            headCamera.fieldOfView = distance;
            camBlurEffect.ShaderEfx.SetFloat(blurRadius, blurMaxRadius += 0.0005f);
            yield return new WaitForSeconds(rotateBackSpeed);
        }

        playerController.SetMoveSpeed(2f);

        transform.localRotation = originRotation;
        headCamera.fieldOfView = originFOV;
        camBlurEffect.ShaderEfx.SetFloat(blurRadius, 0);
        blink.SetActive(false);
        camBlurEffect.enabled = false;

        playerController.SetMoveSpeed(playerController.originSpeed);
    }
}
