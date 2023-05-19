using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour, IEnemyBehavior
{
    [SerializeField] protected float viewingDistance;
    [SerializeField] protected LayerMask viewedLayer;
    [SerializeField] private LayerMask lightMask;
    [SerializeField] private float timeDelayLightDetected;
    protected EnemyAI ai;
    

    private void Awake()
    {
        ai = GetComponent<EnemyAI>();
    }

    public void LightDetected()
    {

        ai.SetBehaviorFearLight();
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void UpdateBehavior() { }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.IsTouchingLayers(lightMask));
    //    {
    //        GameObject target;
    //        if (AccessoryMetods.CheckVisible(transform.position, collision.gameObject.transform.position, viewedLayer, out target))
    //        {
    //            if ( ta )
    //            ai.SetBehaviorFearLight();
    //        }
    //    }
    //}
    
}