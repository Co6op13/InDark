using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class TaskPatrol : Node
{
    private Transform transform;
    private Transform[] waipoints;

    private int currentWaipoint = 0;
    private float waitTime = 1f;
    private float waitCounter = 0f;
    private bool waiting = false;
    public TaskPatrol(Transform transform, Transform[] waipoints)
    {
        this.transform = transform;
        this.waipoints = waipoints;
    }

    public override NodeState Evalute()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            waiting = false;
        }
        else
        {
            Transform wp = waipoints[currentWaipoint];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;

                currentWaipoint = (currentWaipoint + 1) % waipoints.Length;
            }
        }

    }
}
