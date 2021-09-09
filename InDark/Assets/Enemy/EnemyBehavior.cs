using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Enemy
{
    public class EnemyBehavior : MonoBehaviour
    {
        private Dictionary<Type, iEnemyBehavior> behaviorMap;
        private iEnemyBehavior behaviorCurrent;

        private void Start()
        {
            this.InitBehaviors();
            this.SetDefaultBehavior();
        }

        private void InitBehaviors()
        {
            this.behaviorMap = new Dictionary<Type, iEnemyBehavior>();

            this.behaviorMap[typeof(EnemyBehaviorIdle)] = new EnemyBehaviorIdle();
            this.behaviorMap[typeof(EnemyBehaviorPatrol)] = new EnemyBehaviorPatrol();
            this.behaviorMap[typeof(EnemyBehaviorMove)] = new EnemyBehaviorMove();
            this.behaviorMap[typeof(EnemyBehaviorAttack)] = new EnemyBehaviorAttack();
        }

        private void SetNewBehavior(iEnemyBehavior newBehavior)
        {
            //if (newBehavior != behaviorCurrent)
            //{
                if (this.behaviorCurrent != null)
                    this.behaviorCurrent.Exit();

                this.behaviorCurrent = newBehavior;
                this.behaviorCurrent.Enter();
            //}
        }

        private void SetDefaultBehavior()
        {
            this.SetBehaviorIdle();
        }
        
        private iEnemyBehavior GetBehavior<T>() where T :iEnemyBehavior
        {
            var type = typeof(T);
            return this.behaviorMap[type];
        }

        private void Update()
        {
            if (this.behaviorCurrent != null)
                this.behaviorCurrent.Update();
        }

        internal void SetBehaviorIdle()
        {
            var behavior = this.GetBehavior<EnemyBehaviorIdle>();
            this.SetNewBehavior(behavior);

        }
        internal void SetBehaviorMove()
        {
            var behavior = this.GetBehavior<EnemyBehaviorMove>();
            this.SetNewBehavior(behavior);
        }
        internal void SetBehaviorAttack()
        {
            var behavior = this.GetBehavior<EnemyBehaviorAttack>();
            this.SetNewBehavior(behavior);
        }
    }
}
