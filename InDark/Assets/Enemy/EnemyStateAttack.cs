using UnityEditor;
using UnityEngine;

namespace Assets.Enemy
{
    [CreateAssetMenu]
    public class EnemyStateAttack : BaseState
    {
        internal override void Run()
        {
            if ((enemy.transform.position - enemy.FoundTarget.transform.position).sqrMagnitude > 0.5)
            {
                enemyStateMachine.MoveTo(enemy.FoundTarget.transform.position, enemy.speedMovemetnInAgressiv);
            }
        }
    }
}