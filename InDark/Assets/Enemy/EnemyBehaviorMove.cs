using System.Collections;
using UnityEngine;

namespace Assets.Enemy
{
    public class EnemyBehaviorMove :  iEnemyBehavior
    {
        public void Enter()
        {
            Debug.Log(" enter move");
        }

        public void Exit()
        {
            Debug.Log(" exit move");
        }

        public void Update()
        {
            Debug.Log(" update move");
        }
    }
}