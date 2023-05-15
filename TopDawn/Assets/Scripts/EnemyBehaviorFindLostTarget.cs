using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehaviorFindLostTarget : Behavior
{
    [SerializeField] private float searchRadius;
    [SerializeField] private LayerMask obstacle;
    [SerializeField] private Transform emptyGameObject;
    [SerializeField] private Transform[] pointSarch;
    [SerializeField] private int currentPointIndex;
    [SerializeField] private float timeWaitinPoint;


    public override void Enter()
    {
        ai.CanMovie = false;
        for (int i = 0; i < pointSarch.Length; i++)
        {
            pointSarch[i].position = GetRandomPositionWithCheckVisible();
        }
        Debug.Log("FindLostTarget Enter");
        currentPointIndex = 0;
        Invoke("Wait", timeWaitinPoint);
    }

    private void Wait()
    {
        ai.CanMovie = true;
    }

    private Vector2 GetRandomPositionWithCheckVisible()
    {       
        Vector2 newPosition = transform.position;
        bool p = false;
        while (!p)
        {
            newPosition = ai.Rb.position + new Vector2(Random.Range(-searchRadius, searchRadius), Random.Range(-searchRadius, searchRadius));
            if (!IsVisibleObject.CheckVisible(transform.position, newPosition, obstacle))
            {
                p = true;
                break;
            }

        }
        Debug.Log(p);
       

        return newPosition;
    }

    public override void Exit()
    {
        
        Debug.Log("FindLostTarget Exit");
    }

    public override void UpdateBehavior()
    {
        CheckWaypoint();
        CheckPlayer();
    }

    private void CheckWaypoint()
    {
        if (Vector2.Distance(pointSarch[currentPointIndex].transform.position, ai.transform.position) > 1f)
        {
            ai.TargetToMovie = pointSarch[currentPointIndex].transform;
        }
        else
        {
            GetNextPatrolpoint();
            ai.CanMovie = false;
            Invoke("Wait", timeWaitinPoint);
        }
    }

    private void CheckPlayer()
    {
        if (IsVisibleObject.CheckVisible(ai.Rb.transform, ai.PlayerTarget, viewingDistance, viewedLayer))
        {          
            ai.Aggressiv = true;
            ai.SetBehaviorStalker();
        }
    }

    private void GetNextPatrolpoint()
    {
        currentPointIndex++;      
        if (currentPointIndex >= pointSarch.Length)
        {
            ai.Aggressiv = false;
            ai.SetBehaviorPatrol();
        }
    }
}