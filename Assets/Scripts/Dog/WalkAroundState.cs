using System.Collections;
using UnityEngine;

namespace SpaceGame.Dog
{
    public class WalkAroundState : DogStateMachineBase
    {
        [SerializeField] private float timeForNewDestination = 1.0f;
        [SerializeField] private float dwellingTime = 5.0f;

        private bool isWalkingAround = false;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            timeForNewDestination = animator.GetComponent<DogAgent>().GetWalkAroundTimeSetting().Item1;
            dwellingTime = animator.GetComponent<DogAgent>().GetWalkAroundTimeSetting().Item2;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!isWalkingAround)
                animator.GetComponent<DogAgent>().StartCoroutine(WalkAround());
        }

        private IEnumerator WalkAround()
        {
            isWalkingAround = true;
            yield return new WaitForSeconds(timeForNewDestination);
            MoveTo(GetRandomPosition());
            yield return new WaitForSeconds(dwellingTime);
            isWalkingAround = false;
        }

        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{

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
