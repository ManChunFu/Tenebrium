using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLights : MonoBehaviour
{
    
    public float rotateSpeed = 2f;
    float rotation = 0;
    [SerializeField] Light []lights;

    [SerializeField] bool isActive = false;

    private void Awake()
    {
        if (isActive)
        {
            
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = true;
            }
        }
        else
        {
            
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = false;
            }
        }
    }
    void Update()
    {
        if (isActive)
        {
            rotation += Time.deltaTime * rotateSpeed;

            transform.localRotation = Quaternion.Euler(0, 0, rotation);
        }
        
    }
   



    public void LightsOnOFF()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = !lights[i].enabled;
        }
        isActive = !isActive;
    }



    public void LightsOn()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }
        isActive = true;
    }
    public void LightsOFF()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }
        isActive = false;

    }
}
