using UnityEngine;

namespace SpaceGame.Dog
{
    public class NextToPlayer : DogStateMachineBase
    {
        [SerializeField] private float rotationSpeed = 1.5f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }

        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{

        //}

        //OnStateMove is called right after Animator.OnAnimatorMove()
        override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            FaceToPlayer(player.root.position, rotationSpeed);
        }

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
