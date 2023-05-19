using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

///[SelectionBase]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] public Transform TargetToMovie;
    [SerializeField] public Transform PlayerTarget;
    [SerializeField] public bool CanMovie;
    [SerializeField] public bool Aggressiv;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Seeker seeker;
    [SerializeField] private PathWalker pathWalker;

    public bool isSeePlayer;
    [SerializeField] private Dictionary<Type, IEnemyBehavior> behavioraMap;
    private IEnemyBehavior behaviorCurrent;

    public PathWalker PathWalker { get => pathWalker; }
    public Rigidbody2D Rb { get => rb; }
    public Seeker Seeker { get => seeker;  }

    private void Start()
    {
        this.InitBehaviors();
        this.SetBehaviorDefault();
    }

    private void InitBehaviors()
    {
        this.behavioraMap = new Dictionary<Type, IEnemyBehavior>();

        this.behavioraMap[typeof(EnemyBehaviorPatrol)] = GetComponent<EnemyBehaviorPatrol>();
        this.behavioraMap[typeof(EnemyBehaviorStalker)] = GetComponent<EnemyBehaviorStalker>();
        this.behavioraMap[typeof(EnemyBehaviorAttack)] = GetComponent<EnemyBehaviorAttack>();
        this.behavioraMap[typeof(EnemyBehaviorFindLostTarget)] = GetComponent<EnemyBehaviorFindLostTarget>();
        this.behavioraMap[typeof(EnemyBehavirFearLight)] = GetComponent<EnemyBehavirFearLight>();

    }
    private void SetBehaviorDefault()
    {
        SetBehaviorPatrol();
    }

    public void SetBehavir(IEnemyBehavior newBehavior)
    {
        if (this.behaviorCurrent != null)
            this.behaviorCurrent.Exit();

        this.behaviorCurrent = newBehavior;
        this.behaviorCurrent.Enter();
    }


    private IEnemyBehavior GetBehavior<T>() where T : IEnemyBehavior
    {
        var type = typeof(T);
        return this.behavioraMap[type];
    }

    public void SetBehaviorPatrol()
    {
        var behavior = this.GetBehavior<EnemyBehaviorPatrol>();
        this.SetBehavir(behavior);
    }

    public void SetBehaviorStalker()
    {
        var behavior = this.GetBehavior<EnemyBehaviorStalker>();
        this.SetBehavir(behavior);
    }

    public void SetBehaviorFindLostTarget()
    {
        var behavior = this.GetBehavior<EnemyBehaviorFindLostTarget>();
        this.SetBehavir(behavior);
    }

    public void SetBehaviorFearLight()
    {
        var behavior = this.GetBehavior<EnemyBehavirFearLight>();
        this.SetBehavir(behavior);
    }

    private void FixedUpdate()
    {
        behaviorCurrent?.UpdateBehavior();
    }
}
