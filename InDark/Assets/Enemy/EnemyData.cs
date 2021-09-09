using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Enemy
{
    public class EnemyData : MonoBehaviour
    {
        [SerializeField] internal float speedMovemetnInPatrol;
        [SerializeField] internal float speedMovemetnInAgressiv;
        [SerializeField] internal int maxHP;
        [SerializeField] internal int damage;
        [SerializeField, Tooltip("distance at which Enemy can see their target")]
        internal float viewDistance;
        [SerializeField, Tooltip("distance at which it is afraid of light")]
        internal float distanceAfraidLight;
        [SerializeField] internal bool isAfraidLight;
        [SerializeField, Tooltip("lag between Enemy can see their target")]
        internal float timeLagBetweenViews = 0.2f;

        [SerializeField] internal GameObject[] targetToAttack;
        internal EnemyBehavior behavior;


        void Awake ()
        {
            targetToAttack = GameObject.FindGameObjectsWithTag("Player");

        }
    }
}