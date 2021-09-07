using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace character
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class CharacterMovement : MonoBehaviour
    {
        private CharacterData character;
        private Vector2 velocity;
        //Animation States
        const string CHARACTER_IDLE = "CharacterIdle";
        const string CHARACTER_RUN = "CharacterRun";
        const string CHARACTER_WALK = "CharacterWalk";
        const string CHARACTER_ROLL = "CharacterRoll";

        private void Awake()
        {
            character = gameObject.GetComponent<CharacterData>();            
      
        }

        private void Update()
        {
            if (character.input.isRollPressed)
                Roll();
            else if (character.input.isAlternativePressed)
                    Movement(character.runSpeed);
                else
                    Movement(character.walkSpeed);
            //}
            OnCollisionWall();
        }

        private void OnCollisionWall()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, character.boxCollider2D.size, 0);
            foreach (Collider2D hit in hits)
            {
                if (hit == character.boxCollider2D)
                    continue;

                ColliderDistance2D colliderDistance = hit.Distance(character.boxCollider2D);

                if (colliderDistance.isOverlapped)
                {
                    transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                }
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(velocity * Time.deltaTime);
        }

        private void Roll()
        {     
             velocity.x = Mathf.MoveTowards(velocity.x, character.rollSpeed * character.input.moveInputX, character.Acceleration * Time.deltaTime);
             velocity.y = Mathf.MoveTowards(velocity.y, character.rollSpeed * character.input.moveInputY, character.Acceleration * Time.deltaTime);           
        }

        private void Movement(float speed)
        {

            if (character.input.moveInputX != 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, speed * character.input.moveInputX, character.Acceleration * Time.deltaTime);
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, character.Deceleration * Time.deltaTime);
            }

            if (character.input.moveInputY != 0)
            {
                velocity.y = Mathf.MoveTowards(velocity.y, speed * character.input.moveInputY, character.Acceleration * Time.deltaTime);
            }
            else
            {
                velocity.y = Mathf.MoveTowards(velocity.y, 0, character.Deceleration * Time.deltaTime);
            }
        }

        //=====================================================
        // mini animation manager
        //=====================================================
        //void ChangeAnimationState(string newAnimation)
        //{
        //    if (currentAnimaton == newAnimation) return;
        //    animatorGFX.Play(newAnimation);
        //    currentAnimaton = newAnimation;
        //}
    }
}