using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace SpaceGame.Dog
{
    public enum InPlayerHandOptions
    {
        Question,
        Happy,
        Sad
    }

    [RequireComponent(typeof(NavMeshAgent))]
    public class DogAgent : MonoBehaviour
    {
        [Header("Random walk setting")]
        [SerializeField] private Transform dogPlaceOfPlayer = null;
        [SerializeField] private float timeForNewDestination = 1.0f;
        [SerializeField] private float dwellingTime = 5.0f;
        [Header("Speed setting")]
        [SerializeField] private float distanceToSpeedUp = 10.0f;
        [SerializeField] private float speedUpRate = 6.0f;
        [SerializeField] private float distanceBackToNormalSpeed = 4.0f;
        [SerializeField] private float normalSpeedRate = 2.0f;
        [Header("Picked up by player")]
        [SerializeField] private PickUpItem function = null;
        [Header("Puzzle position")]
        [SerializeField] private Transform target;
 
        public NavMeshAgent DogNavMeshAgent { get; private set; }
        public bool hasMetPlayer { get; private set; }
        public Vector3 callingDestination { get; private set; }
        public bool ShouldStay { get; private set; }
        public bool IsInPlayerHand { get; private set; }
        public float NormalSpeed => normalSpeedRate;
        public float SpeedUp => speedUpRate;
        public Transform Target => target;

        private Animator dogAnimator = null;
        private int playerDistanceID = Animator.StringToHash("PlayerDistance");
        private int toDoorID = Animator.StringToHash("ToDoor");
        private int callingDogID = Animator.StringToHash("Calling");
        private int inPlayerHandID = Animator.StringToHash("InPlayerHand");
        private int happyID = Animator.StringToHash("Happy");
        private int questionID = Animator.StringToHash("Question");
        private int sadID = Animator.StringToHash("Sad");
        private int dieID = Animator.StringToHash("Die");

        private DogFloating dogFloating = null;
        private InPlayerHandOptions inHandOptions = InPlayerHandOptions.Happy;
        private bool isInCoroutine = false;

        private void Awake()
        {
            IsInPlayerHand = false;
            DogNavMeshAgent = GetComponent<NavMeshAgent>();
            DogNavMeshAgent.speed = normalSpeedRate;
            dogAnimator = GetComponent<Animator>();
            dogFloating = GetComponentInChildren<DogFloating>();

            if (function != null)
            {
                function.dropped += EnableDogAllFunctions;
                function.pickedUp += DisableDogAllFunctions;
            }

            if (dogPlaceOfPlayer == null)
                throw new MissingReferenceException("Missing transform reference of dog place of the player");

            if (target == null)
                throw new MissingReferenceException("Missing transform reference of puzzle2");
        }

        private void Update()
        {
            if (!hasMetPlayer)
                return;

            if (!IsInPlayerHand)
            {
                // Updating distance to the player
                dogAnimator.SetFloat(playerDistanceID, DistanceToPlayer());

                if (DistanceToPlayer() >= distanceToSpeedUp)
                    DogNavMeshAgent.speed = speedUpRate;
                else if (DistanceToPlayer() <= distanceBackToNormalSpeed)
                    DogNavMeshAgent.speed = normalSpeedRate;
            }
            else
            {
                if (!isInCoroutine)
                    StartCoroutine(InHandModeCoroutine());
            }
        }

        public Transform GetPlayer()
        {
            return dogPlaceOfPlayer;
        }

        public Tuple<float, float> GetWalkAroundTimeSetting()
        {
            return new Tuple<float, float>(timeForNewDestination, dwellingTime);
        }

        public void HasMetPlayer(bool boolean)
        {
            hasMetPlayer = boolean;
            SoundManager.Sound.SFX.DogHappy.Post(gameObject);
        }

        public void CallDogToFollow()
        {
            if (!IsInPlayerHand)
                dogAnimator.SetTrigger(toDoorID);
        }

        public void MoveTo(GameObject gameObject)
        {
            if (IsInPlayerHand)
            {
                function.DropOverride();
                StartCoroutine(MoveToCoroutine(gameObject));
            }
            else
                callingDestination = new Vector3(gameObject.transform.position.x, DogNavMeshAgent.transform.position.y, gameObject.transform.position.z);

            dogAnimator.SetBool(callingDogID, true);
        }

        public void ShouldDogStay(bool shouldStay)
        {
            ShouldStay = shouldStay;
        }

        private void EnableDogAllFunctions()
        {
            IsInPlayerHand = false;
            dogAnimator.SetBool(inPlayerHandID, false);
            dogFloating.enabled = true;
            DogNavMeshAgent.enabled = true;
            GetComponent<Collider>().enabled = true;
        }

        private void DisableDogAllFunctions()
        {
            IsInPlayerHand = true;
            dogAnimator.SetBool(inPlayerHandID, true);
            dogFloating.enabled = false;
            DogNavMeshAgent.enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        private IEnumerator MoveToCoroutine(GameObject gameObject)
        {
            yield return new WaitForSeconds(0.5f);
            callingDestination = new Vector3(gameObject.transform.position.x, DogNavMeshAgent.transform.position.y, gameObject.transform.position.z);
        }

        private float DistanceToPlayer()
        {
            return Mathf.Abs(Vector3.Distance(DogNavMeshAgent.transform.position, dogPlaceOfPlayer.position));
        }

        // animation event
        private void Happy()
        {
            SoundManager.Sound.SFX.DogHappy.Post(gameObject);
        }
        
        private IEnumerator InHandModeCoroutine()
        {
            isInCoroutine = true;

            RunInHandOptions();
            float clipLengh = dogAnimator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(clipLengh + 5f);
            isInCoroutine = false;
        }

        private void RunInHandOptions()
        {
            int option = UnityEngine.Random.Range(1, 4);
            inHandOptions = (InPlayerHandOptions)option;

            switch (inHandOptions)
            {
                case InPlayerHandOptions.Question:
                    dogAnimator.SetBool(questionID, true);
                    break;
                case InPlayerHandOptions.Happy:
                    dogAnimator.SetBool(happyID, true);
                    break;
                case InPlayerHandOptions.Sad:
                    dogAnimator.SetBool(sadID, true);
                    break;
                default:
                    dogAnimator.SetBool(happyID, true);
                    break;
            }
        }
    }
}
