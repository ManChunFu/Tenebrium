using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHover : MonoBehaviour
{
    private Vector3 _currentPos;
    private Vector3 _previousPos;
    private float _velocity;
    private bool _paused;

    void Start()
    {
        SoundManager.Sound.SFX.DogHover.Post(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) CheckInput();
        if (_paused) return;
        Velocity();
    }

    private void CheckInput()
    {
        if (_paused) _paused = false;
        else _paused = true;
    }

    private void Velocity()
    {        
        _currentPos = transform.position;
        _velocity = (_currentPos - _previousPos).magnitude;
        if (_velocity > 0.8) _velocity = 0.8f;
        AkSoundEngine.SetRTPCValue("VelocityRESA", _velocity, gameObject);
        _previousPos = _currentPos;
    }
}
