using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    [SerializeField] private float flickerDuration = 5.0f;
    [SerializeField] private float intensityRadius = 5.0f;
    [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    private Light objectLight = null;
    private float originIntensity = 0.0f;
    private void Awake()
    {
        objectLight = GetComponent<Light>();
        originIntensity = objectLight.intensity;
    }

   
    public void FlickerLight()
    {
        StartCoroutine(FlickerLightCoroutine());
    }

    private IEnumerator FlickerLightCoroutine()
    {
        float time = flickerDuration;
        while (time > 0)
        {
            time -= Time.deltaTime;
            objectLight.intensity = intensityRadius * curve.Evaluate(1f - time / flickerDuration);
            yield return null;
        }
        objectLight.intensity = originIntensity;
    }
}
