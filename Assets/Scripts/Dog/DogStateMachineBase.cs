using UnityEngine;
using UnityEngine.AI;

namespace SpaceGame.Dog
{
    public abstract class DogStateMachineBase : StateMachineBehaviour
    {
        protected GameObject dog;
        protected Transform player;
        protected NavMeshAgent dogNavMeshAgent;
        protected NavMeshPath dogPath;
        protected float normalSpeed;
        protected float speedUp;
        private Vector3 randomPosition = Vector3.zero;


        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            dog = animator.gameObject;
            dogNavMeshAgent = dog.GetComponent<NavMeshAgent>();
            normalSpeed = dog.GetComponent<DogAgent>().NormalSpeed;
            speedUp = dog.GetComponent<DogAgent>().SpeedUp;
            player = dog.GetComponent<DogAgent>().GetPlayer();
            dogPath = new NavMeshPath();
        }

        public void MoveTo(Vector3 destination)
        {
            if (!dogNavMeshAgent.CalculatePath(destination, dogPath))
            {
                dogNavMeshAgent.isStopped = true;
                destination = GetRandomPosition();
            }

            if (dogNavMeshAgent.isStopped)
                dogNavMeshAgent.isStopped = false;

            dogNavMeshAgent.SetDestination(destination);
        }

        public Vector3 GetRandomPosition()
        {
            randomPosition.x = Random.Range(-5f, 5f);
            randomPosition.z = Random.Range(-5f, 5f);

            return new Vector3(dogNavMeshAgent.nextPosition.x + randomPosition.x, dogNavMeshAgent.nextPosition.y, dogNavMeshAgent.nextPosition.z + randomPosition.z);
        }

        public void FaceToPlayer(Vector3 targetPosition, float rotationSpeed)
        {
            Vector3 direction = (targetPosition - dogNavMeshAgent.transform.position).normalized;
            Quaternion newRotation = Quaternion.LookRotation(direction);
            newRotation.x = 0;
            newRotation.z = 0;
            dogNavMeshAgent.transform.rotation = Quaternion.Lerp(dogNavMeshAgent.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
