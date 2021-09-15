using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player :MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float runSpeed = 6f;
        [SerializeField] private float rollRange = 4f;
        [SerializeField] private float rollTime = 1f;

        internal KeyboardInput input;
        private Movement movement;
        private Rigidbody2D rigidbody2d;
        private PlayerAnimation animation;
        internal bool isRoll =false;

        private void Start()
        {

            rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
            //rigidbody.isKinematic = true;
            input = gameObject.GetComponent<KeyboardInput>();
            movement = gameObject.GetComponent<Movement>();
        }

        private void FixedUpdate()
        {
           if(input.direction != Vector2.zero)
                Move();
        }

        private void Move()
        {
            if (input.isRollPressed)
            {
                movement.Roll(rigidbody2d, input.direction, rollRange);
                Invoke("RollComplite", rollTime);

            }
            if (!isRoll )
            {
                if (input.isAlternativePressed)
                    movement.MovePosition(rigidbody2d, input.direction,runSpeed);
                else
                    movement.MovePosition(rigidbody2d, input.direction, walkSpeed);
            }
        }


        void RollComplite()
        {
            isRoll = false;
        }

    }    
}
