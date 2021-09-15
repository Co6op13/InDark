using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField] internal bool isActiv;
        [SerializeField] internal bool isAgressiv;
        [SerializeField] internal bool isSearch;
        [SerializeField] internal float patrolRange;

        [SerializeField] internal int maxHP;
        [SerializeField] internal float passivSpeed;
        [SerializeField] internal float agressivSpeed;
        internal float timeLagBetweenViews = 0.5f;
        internal bool isLagView = false;
        internal Vector3 startPoint;
        internal BaseState currentState;
        internal Rigidbody2D rigidbody2d;
        internal virtual void Start()
        {
            rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
            startPoint = rigidbody2d.position;
        }


        protected void SetState(BaseState state)
        {
            currentState = Instantiate(state);
            currentState.enemy = this;
            currentState.Init();
        }


        internal void LagView(float lag)
        {
            Debug.Log("Lag");
            isLagView = true;
            Invoke("CancelLagView", lag);
        }

        void CancelLagView()
        {
            isLagView = false;
        }
    }
}