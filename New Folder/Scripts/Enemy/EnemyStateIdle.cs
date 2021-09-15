using UnityEditor;
using UnityEngine;

namespace Scripts.Enemy
{
    [CreateAssetMenu]
    public class EnemyStateIdle : BaseState
    {
        internal override void Run()
        {
            if (enemy.isActiv)
            {
                isFinished = true;
            }
        }

    }
}