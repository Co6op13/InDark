using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
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

        internal void Attaking(GameObject target)
        {
            if (!enemy.isAttaking)
            {
                if (target.gameObject.GetComponent<HealthData>() != null)
                {
                    enemy.isAttaking = true;
                    Debug.Log("типа атака");
                    target.gameObject.GetComponent<HealthData>().GetDamage(enemy.damage);
                    Invoke("CancelThisAttack", enemy.attackSpeed);
                }               
            }
        }

        void CancelThisAttack()
        {

            enemy.isAttaking = false;
        }

        internal void LagView(float lag)
        {
            Debug.Log("Lag");
            enemy.isLagView = true;
            Invoke("CancelLagView", lag);
        }

        void CancelLagView()
        {
            enemy.isLagView = false;
        }

        internal Vector3 GetDirection(Vector3 rayStart, Vector3 rayEnd)
        {
            var dir = enemy.transform.TransformVector(rayEnd - rayStart);            
            Debug.DrawRay(rayStart, dir, Color.red);
            return dir;
        }
    }
}