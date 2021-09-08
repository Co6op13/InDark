using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterInput : MonoBehaviour
    {
        private CharacterData character;
        [SerializeField] internal float moveInputX;
        [SerializeField] internal float moveInputY;
        [SerializeField] internal bool isRollPressed = false;
        internal bool isAlternativePressed = false;

        // Start is called before the first frame update
        void Start()
        {
            character = gameObject.GetComponent<CharacterData>();

        }

        // Update is called once per frame
        void Update()
        {
            moveInputX = Input.GetAxisRaw("Horizontal");
            moveInputY = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Roll") && ((moveInputX != 0) | (moveInputY != 0)))
            {
                isRollPressed = true;
            }
            else isRollPressed = false;
       
            //if (!isRollPressed)
            //{
                if (Input.GetButton("Alternative"))
                    isAlternativePressed = true;
                else
                    isAlternativePressed = false;
            //}
        }


    }
}