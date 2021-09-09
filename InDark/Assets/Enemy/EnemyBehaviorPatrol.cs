using System.Collections;
using UnityEngine;

namespace Assets.Enemy
{
    public class EnemyBehaviorPatrol :  iEnemyBehavior
    {
        public void Enter()
        {
            Debug.Log(" enter patrol");
        }

        public void Exit()
        {
            Debug.Log(" exit patrol");
        }

        public void Update()
        {
            Debug.Log(" update patrol");
        }
    }
}