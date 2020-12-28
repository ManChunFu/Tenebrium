using System.Collections;
using UnityEngine;

namespace SpaceGame.Dog
{
    public class TeleportDog : LocationSharing
    {
        [SerializeField] private float waitingTimeBeforeTrackLocation = 5.0f;
        [SerializeField] private float waitTimeBeforeTeleport = 3.0f;
        [SerializeField] private CheckVisibility checkVisibility = null;

        private Vector3 targetDogDoorPosition = Vector3.zero;
        private DogAgent dogAgent;

        public override void Awake()
        {
            base.Awake();
            dogAgent = GetComponent<DogAgent>();
        }

        private void Start()
        {
            if (checkVisibility == null)
                checkVisibility = FindObjectOfType<CheckVisibility>();
        }

        public void TrackPlayerLocation()
        {
            StartCoroutine(PlayerLocationTrackingCortouine());
        }

        private IEnumerator PlayerLocationTrackingCortouine()
        {
            if (!dogAgent.hasMetPlayer ||  dogAgent.IsInPlayerHand)
                yield break;

            yield return new WaitForSeconds(waitingTimeBeforeTrackLocation);
            if (locationData.PlayerCurrentRoomNo != locationData.DoggyCurrentRoomNo)
            {
                targetDogDoorPosition = locationData.GetDogDoorLocation(locationData.PlayerCurrentRoomNo);
                TeleportToDogDoor();
                yield break;
            }
        }


        private void TeleportToDogDoor()
        {
            StartCoroutine(TeleportToDogDoorCoroutine());
        }
        private IEnumerator TeleportToDogDoorCoroutine()
        {
            while (checkVisibility.CanSeeDog())
            {
                yield return new WaitForSeconds(waitTimeBeforeTeleport);
            }

            dogAgent.StopAllCoroutines();
            dogAgent.DogNavMeshAgent.enabled = false;
            dogAgent.DogNavMeshAgent.Warp(targetDogDoorPosition);
            dogAgent.DogNavMeshAgent.enabled = true;
            UpdateRoomNoAtEditor();
        }

        private void UpdateRoomNoAtEditor()
        {
            roomNo = locationData.DoggyCurrentRoomNo;
        }
    }
}
