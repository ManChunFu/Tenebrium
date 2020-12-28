
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Light[] lights;
    public Color color;
    public void ChangeColor()
    {
        foreach (Light light in lights)
        {
            light.color = color;
        }
    }
    
    public void SetColor(Color newColor)
    {
        color = newColor;
    }
}
