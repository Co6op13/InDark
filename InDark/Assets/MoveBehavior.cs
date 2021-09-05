using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : StateMachineBehaviour
{
    [SerializeField] private Transform transformThis;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float movmentSpeed = 5f;
   //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transformThis = animator.transform.parent.transform;
        Debug.Log("состояние муве");
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;

    }

  //  OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(transformThis.transform.position, targetPosition.position) < 1)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttack", true);
        }
        else
            if (targetPosition != null)
        {
            Debug.Log("состояние муве2   "+ targetPosition);
            //animator.transform.position = Vector2.MoveTowards(animator.transform.position, targetPosition.position, movmentSpeed * Time.deltaTime);
            transformThis.position = Vector2.MoveTowards(transformThis.position, targetPosition.position, movmentSpeed * Time.deltaTime);
        }
        
        
            
        
        Debug.Log(Vector2.Distance(transformThis.transform.position, targetPosition.position));

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

    }

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
