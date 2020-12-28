using UnityEngine;

public enum EndingType
{
    AIVictory = 1,
    HumanVictory = 2,
    CryWithDog = 3,
    VariantEnd_1 = 4,
    VariantEnd_2 = 5
}

[CreateAssetMenu(fileName = "GameEndVOScript", menuName = "Unity-SpaceGame/GameEnd", order = 2)]
public class GameEndScriptable : ScriptableObject
{
    public EndingType selectedEndingType { get; private set; }

    private void Awake()
    {
        selectedEndingType = EndingType.AIVictory;
    }

    public void SetEndingType(EndingType endingType)
    {
        selectedEndingType = endingType;
    }

}
