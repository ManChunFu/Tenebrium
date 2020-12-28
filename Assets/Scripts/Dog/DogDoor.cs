namespace SpaceGame.Dog
{
    public class DogDoor : LocationSharing
    {
        private void Start()
        {
            locationData.RegisterDogDoorLocation(roomNo, transform.position);
        }
    }
}
