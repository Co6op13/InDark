using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavirFearLight : Behavior
{
    public override void Enter()
    {
        Debug.Log("FearLight Enter");
        ai.CanMovie = false;
    }

    public override void Exit()
    {
        Debug.Log("FearLight Exit");
    }
    public override void UpdateBehavior()
    {
    }
}
