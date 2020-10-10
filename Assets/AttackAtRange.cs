using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAtRange : StateMachineBehaviour
{
    TowerManager tm;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tm = animator.GetComponent<TowerManager>();
        animator.speed = tm.self.attackCooldown;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (tm.currentTarget != null)
        {
            tm.AttackTarget();
        }
        else
        {
            animator.SetBool("hasTarget", false);
        }
    }

// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = 1;
    }
}


