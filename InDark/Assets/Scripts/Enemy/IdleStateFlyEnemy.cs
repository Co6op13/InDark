using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [CreateAssetMenu]
    public class IdleStateFlyEnemy : BaseState
    {
        internal override void Init()
        {
            Debug.Log("start idle");
               
        }

        internal override void Run()
        {
            if (enemy.isActiv)
            {
                isFinished = true;
            }
        }
    }
}