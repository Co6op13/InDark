using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavirReaactionToLight : Behavior
{
    [SerializeField] private GameObject lightDetector;
    [SerializeField] private bool lightDetected;
    [SerializeField] private Transform pointToRunAway;

    private Collider2D collider2d;

    public override void Enter()
    {
        Debug.Log("ReaactionToLight Enter");
        ai.TargetToMovie = pointToRunAway;
        ai.CanMovie = true;
    }

    public override void Exit()
    {
        lightDetector.SetActive(true);
        Debug.Log("ReaactionToLight Exit");
    }
    public override void UpdateBehavior()
    {
        Debug.Log("ReaactionToLight Update");
        //if (Vector2.Distance(pointToRunAway.position, transform.position) < 1f)
        //    ai.SetBehaviorPatrol();
    }


}
