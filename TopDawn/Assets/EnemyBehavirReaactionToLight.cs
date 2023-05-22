using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavirReaactionToLight : Behavior
{
    [SerializeField] private LightDetector lightDetector;
    [SerializeField] private bool lightDetected;
    [SerializeField] private Transform pointToRunAway;
    [SerializeField] private int countRunEvey;
    [SerializeField] private GameObject sourceLight;
    [SerializeField] private float distanceAvoidlight;
    [SerializeField] private LayerMask obstacle;
    private int currentCountRunEvey;

    public override void Enter()
    {
        Debug.Log("ReaactionToLight Enter");
        sourceLight = lightDetector.lightObject;
        var direction = (sourceLight.transform.position - transform.position).normalized;
        pointToRunAway.transform.position = transform.position - direction * distanceAvoidlight;
        //pointToRunAway.transform.position = AccessoryMetods.GetPositionAvoidLightWithCheckVisible(transform.position, direction, obstacle); //GetPointAvoidlight();
        ai.TargetToMovie = pointToRunAway;
        ai.CanMovie = true;
    }

    public override void Exit()
    {
        lightDetector.gameObject.SetActive(true);
        Debug.Log("ReaactionToLight Exit");
    }
    public override void UpdateBehavior()
    {
        //Debug.Log("ReaactionToLight Update");
        if (Vector2.Distance(pointToRunAway.position, transform.position) < 1f)        
            ai.SetBehaviorStalker();
    }


}
