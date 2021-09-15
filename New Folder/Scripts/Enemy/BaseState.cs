using UnityEditor;
using UnityEngine;

namespace Scripts.Enemy
{
    public abstract class BaseState : ScriptableObject
    {
        public bool isFinished { get; protected set; }
        [HideInInspector] internal EnemyStateMachine enemyStateMachine;
        [HideInInspector] internal EnemyData enemy;

        internal virtual void Init()
        {
            enemy = enemyStateMachine.gameObject.GetComponent<EnemyData>();
        }
        internal abstract void Run();
    }
}