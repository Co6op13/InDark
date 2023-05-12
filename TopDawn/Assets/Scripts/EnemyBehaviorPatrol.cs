using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviorPatrol : IEnemyBehavior
{
    private EnemyAI ai;
    private PatrolSettings patrolSettings;
    private int currentPointIndex;

    public EnemyBehaviorPatrol(EnemyAI ai, PatrolSettings patrolPath)
    {
        this.ai = ai;
        this.patrolSettings = patrolPath;
    }

    private void CheckWaypoint()
    {
        if (Vector2.Distance(patrolSettings.Path[currentPointIndex].transform.position, ai.transform.position) > 1f)
        {
            ai.TargetToMovie = patrolSettings.Path[currentPointIndex].transform;
        }
        else
            GetNextPatrolpoint();
    }

    private void GetNextPatrolpoint()
    {
        currentPointIndex++;
        if (currentPointIndex >= patrolSettings.Path.Count)
            currentPointIndex = 0;
    }

    public void Enter()
    {
        Debug.Log("Patrol Enter");
        ai.CanMovie = true;
    }

    public void Exit()
    {
        Debug.Log("Patrol Exit");
    }

    public void Update()
    {
        CheckWaypoint();
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        if (Vector2.Distance(ai.PlayerTarget.position, ai.Rb.position) < patrolSettings.ViewingDistance)
        {
            ai.isSeePlayer = true;
            ai.SetBehaviorStalker();
        }
    }
}
