using UnityEngine;

namespace SpaceGame.Dog
{ 
    public class IdleState : DogStateMachineBase
    {
        [SerializeField] private float rotationSpeed = 3.0f;
        private int IsMovingID = Animator.StringToHash("IsMoving");
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            dogNavMeshAgent.speed = normalSpeed;
            animator.SetBool(IsMovingID, false);
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator.GetComponent<DogAgent>().ShouldStay)
                return;
        }

        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
            
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
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

