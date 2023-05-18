using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviorPatrol : Behavior
{

    [SerializeField] private List<Transform> path;
    [SerializeField] private float timeWaitinPoint;

    private int currentPointIndex;

    private void CheckWaypoint()
    {
        if (Vector2.Distance(path[currentPointIndex].transform.position, ai.transform.position) > 1f)
        {
            ai.TargetToMovie = path[currentPointIndex].transform;
        }
        else
        {
            GetNextPatrolpoint();
            ai.CanMovie = false;
            Invoke("Wait", timeWaitinPoint);
        }
    }

    private void GetNextPatrolpoint()
    {
        currentPointIndex++;
        if (currentPointIndex >= path.Count)
            currentPointIndex = 0;
    }

    public override void Enter()
    {
        Debug.Log("Patrol Enter");
        ai.CanMovie = true;
    }

    public override void Exit()
    {
        Debug.Log("Patrol Exit");
    }

    public override void UpdateBehavior()
    {
        CheckWaypoint();
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        if (AccessoryMetods.CheckVisible(ai.Rb.transform, ai.PlayerTarget, viewingDistance, viewedLayer))
        {
            //ai.isSeePlayer = true;
            ai.Aggressiv = true;
            ai.SetBehaviorStalker();
        }
    }

    private void Wait()
    {
        ai.CanMovie = true;
    }
}
