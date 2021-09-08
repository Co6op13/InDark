using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class CharacterMovement : MonoBehaviour
    {
        private CharacterData character;
        private Vector2 velocity;
        internal bool isRoll = false;


        private void Awake()
        {
            character = gameObject.GetComponent<CharacterData>();            
      
        }

        private void Update()
        {
            if (character.input.isRollPressed)
            {
                Roll();
            }
            if (!isRoll)
            {
                if (character.input.isAlternativePressed)
                    Movement(character.runSpeed);
                else
                    Movement(character.walkSpeed);
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(velocity * Time.deltaTime);
        }

        private void Roll()
        {
            isRoll = true;
            velocity.x = Mathf.MoveTowards(velocity.x, character.rollSpeed * character.input.moveInputX, character.Acceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, character.rollSpeed * character.input.moveInputY, character.Acceleration * Time.deltaTime);
            Invoke("RollComplite", character.rollDelay);
        }

        void RollComplite()
        {
            isRoll = false;
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
    }
}