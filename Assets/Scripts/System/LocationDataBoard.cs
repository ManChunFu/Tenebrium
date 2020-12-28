using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LocationData", menuName = "Unity-SpaceGame/LocationData", order = 1)]

public class LocationDataBoard : ScriptableObject
{
    public int PlayerCurrentRoomNo { get; private set; }
    public int DoggyCurrentRoomNo { get; private set; }
    public Dictionary<int, Vector3> DogDoorData { get; private set; }

    private void OnEnable()
    {
        DogDoorData = new Dictionary<int, Vector3>();
    }

    public void RegisterDogDoorLocation(int roomNo, Vector3 position)
    {
        DogDoorData.Add(roomNo, position);
    }

    public void UpdateCharacterLocation(string name, int roomNo)
    {
        if (name == "Player")
            PlayerCurrentRoomNo = roomNo;
        else
            DoggyCurrentRoomNo = roomNo;
    }

    public Vector3 GetDogDoorLocation(int roomNo)
    {
        return DogDoorData[roomNo];
    }
}
