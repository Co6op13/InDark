using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace character
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class CharacterMovement : MonoBehaviour
    {
       // private CharacterData charData;
        [SerializeField, Tooltip("Walk Speed, in units per second, that the character moves.")]
        private float walkSpeed = 4;

        [SerializeField, Tooltip("Roll Speed, in units per second, that the character moves.")]
        private float rollSpeed = 15;

        [SerializeField, Tooltip("Delay after rolling, in units per second, that the character moves.")]
        private float rollDelay = 0.8f;


        [SerializeField, Tooltip("Run Speed, in units per second, that the character moves.")]
        float runSpeed = 8;

        [SerializeField, Tooltip("Acceleration while grounded.")]
        float Acceleration = 75;

        [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
        float Deceleration = 70;
        private Animator animatorGFX;
        private BoxCollider2D thisBoxCollider;
        private Vector2 velocity;
        private float moveInputX;
        private float moveInputY;
        private string currentAnimaton;
        private bool isRollPressed = false;
        //Animation States
        const string CHARACTER_IDLE = "CharacterIdle";
        const string CHARACTER_RUN = "CharacterRun";
        const string CHARACTER_WALK = "CharacterWalk";
        const string CHARACTER_ROLL = "CharacterRoll";

        private void Awake()
        {
            
            animatorGFX = gameObject.transform.GetComponentInChildren<Animator>();
            thisBoxCollider = GetComponent<BoxCollider2D>();
            ChangeAnimationState(CHARACTER_ROLL);
        }

        private void Update()
        {
            
            moveInputX = Input.GetAxisRaw("Horizontal");
            moveInputY = Input.GetAxisRaw("Vertical");

            if (!isRollPressed)
            {
                if (Input.GetButton("Alternative"))
                {
                    Debug.Log("альтернативное управление активированно");
                    Movement(runSpeed);
                    ChangeAnimationState(CHARACTER_RUN);
                    Roll();
                }
                else
                {
                    Movement(walkSpeed);
                    ChangeAnimationState(CHARACTER_WALK);
                    Roll();
                }
                if (moveInputX == 0 && moveInputY == 0)
                    ChangeAnimationState(CHARACTER_IDLE);
                OnCollisionWall();
            }
            
        }

        private void OnCollisionWall()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, thisBoxCollider.size, 0);
            foreach (Collider2D hit in hits)
            {
                if (hit == thisBoxCollider)
                    continue;

                ColliderDistance2D colliderDistance = hit.Distance(thisBoxCollider);

                if (colliderDistance.isOverlapped)
                {
                    transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                }
            }
        }

        private void FixedUpdate()
        {
            //if (isRollPressed)
            //{
            //    Roll();
            //}
            transform.Translate(velocity * Time.deltaTime);
        }

        private void Roll()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Roll");
                isRollPressed = true;          
                velocity.x = Mathf.MoveTowards(velocity.x, rollSpeed * moveInputX, Acceleration * Time.deltaTime);
                velocity.y = Mathf.MoveTowards(velocity.y, rollSpeed * moveInputY, Acceleration * Time.deltaTime);
                ChangeAnimationState(CHARACTER_ROLL);
                Invoke("RollComplite",rollDelay);
            }
        }

        void  RollComplite()
        {
            isRollPressed = false;
        }
        private void Movement(float speed)
        {

            if (moveInputX != 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInputX, Acceleration * Time.deltaTime);
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, Deceleration * Time.deltaTime);
            }

            if (moveInputY != 0)
            {
                velocity.y = Mathf.MoveTowards(velocity.y, speed * moveInputY, Acceleration * Time.deltaTime);
            }
            else
            {
                velocity.y = Mathf.MoveTowards(velocity.y, 0, Deceleration * Time.deltaTime);
            }
        }

        //=====================================================
        // mini animation manager
        //=====================================================
        void ChangeAnimationState(string newAnimation)
        {
            if (currentAnimaton == newAnimation) return;
            animatorGFX.Play(newAnimation);
            currentAnimaton = newAnimation;
        }
    }
}