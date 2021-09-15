using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(BoxCollider2D))]
   // [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyData : HealthData
    {
        [SerializeField] internal bool isActiv = false;
        [SerializeField] internal bool isInSearch = false;
        [SerializeField] internal bool isAgressiv = false;
        [SerializeField] internal bool isAttaking = false;
        [SerializeField] internal float speedMovemetnInPatrol;
        [SerializeField] internal float speedMovemetnInAgressiv;
        [SerializeField] internal int damage;
        [SerializeField] internal float attackSpeed;
        [SerializeField, Tooltip("distance at which Enemy can see their target")]
        internal float viewDistance;
        [SerializeField, Tooltip("distance at which Enemy can Patroling")]
        internal float patrolDistance;
        [SerializeField, Tooltip("distance at which it is afraid of light")]
        internal float distanceAfraidLight;
        [SerializeField] internal bool isAfraidLight;
        [SerializeField, Tooltip("lag between Enemy can see their target")]
        internal float timeLagBetweenViews = 0.5f;
        internal bool isLagView = false;

        [Header ("Activ parameters")]
        [SerializeField] internal GameObject[] targetToAttack;
        [SerializeField] internal LayerMask targetlayerMask;
        [SerializeField] internal EnemyBehavior behavior;
        [SerializeField] internal BaseState stateIdle;
        [SerializeField] internal BaseState stateWalk;
        [SerializeField] internal BaseState stateAttack;
        [SerializeField] internal BaseState statePatrol;

        [SerializeField] internal GameObject FoundTarget;

        internal Vector3 pointStart;
        internal Vector3 pointAgressivPatrol;

        void Awake()
        {
            targetToAttack = GameObject.FindGameObjectsWithTag("Character");
            pointStart = gameObject.transform.position;
            
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    foreach (var taget in targetToAttack)
        //    {
        //        var dir = transform.position + taget.transform.position;               
        //        float direction = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //        Gizmos.DrawLine(transform.position, direction); //(transform.position, dir);
        //    }
        //}
    }
}