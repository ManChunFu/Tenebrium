using System;
using UnityEngine.Events;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public UnityEvent OnDone;
    public event Action<float> tValueNormalized;
    public float startTime = 10f;

    float timeLeft;
    float normalizedValue;
    [SerializeField] bool countingDown;
    public bool debug;
    private void Awake()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        if (countingDown)
        {
            timeLeft -= Time.deltaTime;
            tValueNormalized?.Invoke(NormalizeTime(timeLeft, startTime));


            {
                Debug.Log("Time Left : " + timeLeft);
            }
            if (timeLeft <= 0)
            {
                TimerDone();
                countingDown = false;
            }
        }
    }
    float NormalizeTime(float value, float max)
    {
        return value / max;
    }

    void TimerDone()
    {
        OnDone?.Invoke();
    }
    public void SetTime(float time)
    {
        timeLeft = time;
    }

    public void AddTime(float time)
    {
        timeLeft += time;
    }
    public void RemoveTime(float time)
    {
        timeLeft -= time;
    }
    public void StartTimer()
    {
        countingDown = true;
    }
    public void StopTimer()
    {
        countingDown = false;
    }
    public void ResetTimer()
    {
        timeLeft = startTime;
    }
}
