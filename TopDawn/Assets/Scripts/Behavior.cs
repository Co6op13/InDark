using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Behavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] protected float viewingDistance;
    [SerializeField] protected LayerMask viewedLayer;
    protected EnemyAI ai;

    private void Awake()
    {
        ai = GetComponent<EnemyAI>();
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void UpdateBehavior() { }
}