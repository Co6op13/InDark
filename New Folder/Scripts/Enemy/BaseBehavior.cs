using UnityEditor;
using UnityEngine;

namespace Scripts.Enemy
{
    public abstract class BaseBehavior : ScriptableObject
    {
        public bool isFinished { get; protected set; }
        internal EnemyData enemy;

        internal virtual void Init()
        { }
        internal abstract void Run();

    }
}