using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorStalker : Behavior
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float stalkingTime;
    [SerializeField] private float checkVisibleTarget;
    [SerializeField] private bool targetIsVisible;
    [SerializeField] private float currentStalkingTime;

    public override void Enter()
    {
        ai = GetComponent<EnemyAI>();
        Debug.Log("Stalker mod Enter");
        ai.TargetToMovie = ai.PlayerTarget;
        currentStalkingTime = stalkingTime;
        StartCoroutine(CheckedVisibleTarget());
    }

    private IEnumerator CheckedVisibleTarget()
    {
        while (currentStalkingTime > 0)
        {
            if (targetIsVisible = AccessoryMetods.CheckVisible(ai.Rb.transform, ai.PlayerTarget, viewingDistance, viewedLayer))
            {
                currentStalkingTime = stalkingTime;
            }
            else
            {                
                currentStalkingTime -= checkVisibleTarget;
            }

            yield return new WaitForSeconds(checkVisibleTarget);
        }
        StopCoroutine(CheckedVisibleTarget());
        ai.SetBehaviorFindLostTarget();      
    }

    public override void Exit()
    {
        Debug.Log("Stalker mod Exit");
        StopCoroutine(CheckedVisibleTarget());
    }

    public override void UpdateBehavior()
    {
        StalkingTarget();
    }

    private void StalkingTarget()
    {
        if (targetIsVisible && Vector2.Distance(ai.PlayerTarget.position, ai.Rb.position) < attackDistance)
        {
            ai.CanMovie = false;

        }
        else
        {
            ai.CanMovie = true;
        }
    }
}
