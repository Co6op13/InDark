using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Character
{
    public class CharacterInput : MonoBehaviour
    {
        private CharacterData character;
        internal float moveInputX;
        internal float moveInputY;
        internal bool isRollPressed = false;
        internal bool isAlternativePressed = false;

        void Start()
        {
            character = gameObject.GetComponent<CharacterData>();
        }

        void Update()
        {
            moveInputX = Input.GetAxisRaw("Horizontal");
            moveInputY = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Roll") && ((moveInputX != 0) | (moveInputY != 0)))
            {
                isRollPressed = true;
            }
            else isRollPressed = false;

            if (Input.GetButton("Alternative"))
                isAlternativePressed = true;
            else
                isAlternativePressed = false;
        }
    }
}