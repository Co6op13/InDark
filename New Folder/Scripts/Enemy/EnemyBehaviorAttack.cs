using System.Collections;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyBehaviorAttack : iEnemyBehavior
    {
        public void Enter()
        {
            Debug.Log(" enter attack");
        }

        public void Exit()
        {
            Debug.Log(" exit attack");
        }

        public void Update()
        {
            Debug.Log(" update attack");
        }
    }
}