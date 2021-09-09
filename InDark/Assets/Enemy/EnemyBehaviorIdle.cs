using System.Collections;
using UnityEngine;

namespace Assets.Enemy
{
    public class EnemyBehaviorIdle : StateMachineBehaviour, iEnemyBehavior
    {
        private EnemyData enemy;
        

        private bool isLagViewsCancel = true;
        public void Enter()
        {
            Debug.Log(" enter idle");
        }

        public void Exit()
        {
            Debug.Log(" exit idle");
        }

        public void Update()
        {
            //Debug.Log(" update idle");
        }

        void CancelLag()
        {
            isLagViewsCancel = true;
        }
    }
}