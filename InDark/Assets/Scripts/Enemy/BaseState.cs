using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [CreateAssetMenu]
    public abstract class BaseState : ScriptableObject
    {
        public bool isFinished { get; protected set; }
        [HideInInspector] internal BaseEnemy enemy;

        internal abstract void Init();
        internal abstract void Run();


    }
}
    
