using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[ExecuteAlways]
public class FlickeringLight : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event electricEvent;
    [SerializeField] private float _min = 0.1f;
    [SerializeField] private float _max = 0.5f;
    [SerializeField] private float _intensityMultiplyer = 2f;
    private Light _light;

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Start()
    {
        StartCoroutine(Flashing());
        if (Application.isPlaying) StartCoroutine(StartSound());
    }

    IEnumerator StartSound()
    {
        yield return new WaitForSeconds(3);
        electricEvent.Post(gameObject);
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_min, _max));
            _light.intensity = Random.Range(_min, _max) * _intensityMultiplyer;
            _light.enabled = !_light.enabled;
        }
    }
}
