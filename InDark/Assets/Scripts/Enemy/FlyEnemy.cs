using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class FlyEnemy : BaseEnemy
    {     

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
        internal Movement movement;

        [SerializeField] private BaseState stateIdle;
        [SerializeField] private BaseState statePatrol;
        [SerializeField] private BaseState stateAttack;


        void Start()
        {
            rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
            movement = gameObject.GetComponent<Movement>();
            SetState(stateIdle);
        }

        // Update is called once per frame
        void Update()
        {
            if (!currentState.isFinished)
            {
                currentState.Run();
            }
            else
            {
                if (isAgressiv && isActiv)
                {
                    SetState(stateAttack);
                }
                else if (isActiv)
                {
                    SetState(statePatrol);
                }
            }
        }
    }
}
