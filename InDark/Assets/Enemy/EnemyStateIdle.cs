using UnityEditor;
using UnityEngine;

namespace Assets.Enemy
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