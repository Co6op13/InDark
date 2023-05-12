using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorStalker : IEnemyBehavior
{
    private EnemyAI ai;
    private StalkerSettings stalkerSettings;

    public EnemyBehaviorStalker(EnemyAI ai, StalkerSettings settings)
    {
        this.ai = ai;
        this.stalkerSettings = settings;
    }

    public void Enter()
    {
        Debug.Log("Stalker mod Enter");
        ai.TargetToMovie = ai.PlayerTarget;
        //ai.PathWalker.endReachedDistance = stalkerSettings.attackDistance;
    }

    public void Exit()
    {
        Debug.Log("Stalker mod Exit");
    }

    public void Update()
    {
        Debug.Log(IsVisibleObject.CheckVisible(ai.Rb.transform, ai.PlayerTarget, stalkerSettings.AttackDistance, stalkerSettings.ViewedLayer));
        if (IsVisibleObject.CheckVisible(ai.Rb.transform, ai.PlayerTarget, stalkerSettings.AttackDistance, stalkerSettings.ViewedLayer))
        {
            ai.CanMovie = false;
        }
        else
        {
            ai.CanMovie = true;
        }

    }
}
