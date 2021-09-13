using UnityEditor;
using UnityEngine;

namespace Scripts.Enemy
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
            else
            {
                enemyStateMachine.Attaking(enemy.FoundTarget);
            }


            if (!enemy.isLagView)
            {
                var dir = enemyStateMachine.GetDirection(enemy.transform.position, enemy.FoundTarget.transform.position);
                RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, enemy.transform.TransformVector(dir));

                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Character"))
                {
                    enemy.pointAgressivPatrol = enemy.FoundTarget.transform.position;

                }
            }
        }   
    }
}