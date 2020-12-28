using UnityEngine;

namespace SpaceGame.Dog
{
    public class CallingState : DogStateMachineBase
    {
        private Vector3 destination;
        private int callingID = Animator.StringToHash("Calling");
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            destination = animator.GetComponent<DogAgent>().callingDestination;
            dogNavMeshAgent.speed = speedUp;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            MoveTo(destination);
            if (Vector3.Distance(dog.transform.position, destination) < 0.2f)
                animator.SetBool(callingID, false);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
