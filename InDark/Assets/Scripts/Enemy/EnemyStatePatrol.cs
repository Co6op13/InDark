using UnityEditor;
using UnityEngine;


namespace Scripts.Enemy
{
    [CreateAssetMenu]
    public class EnemyStatePatrol : BaseState
    {
        private Vector3 randomPosition;
        internal override void Init()
        {
            enemy = enemyStateMachine.gameObject.GetComponent<EnemyData>();
            var randomVector = new Vector3(Random.Range(-enemy.patrolDistance, enemy.patrolDistance), Random.Range(-enemy.patrolDistance, enemy.patrolDistance), enemy.transform.position.z);          
            randomPosition = enemy.pointStart + randomVector;           
        }

        internal override void Run()
        {
            MoveRandomPosition();
            if (!enemy.isLagView)
            {
                enemyStateMachine.LagView(enemy.timeLagBetweenViews);
                TargetSearch();
            }
        }

        private void MoveRandomPosition()
        {
            var distance = (randomPosition - enemy.transform.position).magnitude;

            if (distance > 0.2f)            
                enemyStateMachine.MoveTo(randomPosition, enemy.speedMovemetnInPatrol);           
            else           
                isFinished = true;            
        }
        
        private void TargetSearch()
        {
            foreach (var target in enemy.targetToAttack)
            {
                if ((enemy.transform.position - target.transform.position).sqrMagnitude < enemy.viewDistance * enemy.viewDistance)
                {
                    var dir = enemyStateMachine.GetDirection(enemy.transform.position, target.transform.position);
                    //var dir = (target.transform.position - enemy.transform.position);
                    //Debug.DrawRay(enemy.transform.position, enemy.transform.TransformVector(dir), Color.red);
                    RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, dir);

                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Character"))
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        enemy.FoundTarget = hit.collider.gameObject;
                        enemy.isAgressiv = true;
                        isFinished = true;
                    }
                }
            }
        }
    }
}