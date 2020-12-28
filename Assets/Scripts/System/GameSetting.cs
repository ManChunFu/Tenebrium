using UnityEngine;

[CreateAssetMenu(fileName = "GameSetting", menuName = "Unity-SpaceGame/GameSetting", order = 3)]
public class GameSetting : ScriptableObject
{
    public bool EnablePlayerJump;
    public bool EnablePlayerSpeedUp;
    public float LightIntensity;


    

    public void EnableJump(bool enable)
    {
        EnablePlayerJump = enable;
    }

    public void EnableSpeedUp(bool enable)
    {
        EnablePlayerSpeedUp = enable;
    }

    public void ChangeLightIntens(float value)
    {
        LightIntensity = value;
    }
}
