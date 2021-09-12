using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Enemy
{
    
    public class EnemyStateMachine : MonoBehaviour
    {
        internal EnemyData enemy;
        internal BaseState currentState;
        
        void Start()
        {
            enemy = gameObject.GetComponent<EnemyData>();
            SetState(enemy.stateIdle);
        }

        // Update is called once per frame
        void Update()
        {
            if (!currentState.isFinished)
            {
                currentState.Run();
            }
            else
            {

                if (enemy.isAgressiv && enemy.isActiv)
                {
                    SetState(enemy.stateAttack);
                }
                else if (enemy.isActiv)
                {
                    SetState(enemy.statePatrol);
                }
            }           
        }
        void SetState( BaseState state)
        {
            currentState = Instantiate(state);
            currentState.enemyStateMachine = this;
            currentState.Init();
        }

        internal void MoveTo(Vector3 postition, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, postition, Time.deltaTime * speed);
        }


        internal Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        internal float GetAngleFromVectror(Vector3 direction)
        {
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return angle;
        }
    }
}