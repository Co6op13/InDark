using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class KeyboardInput : MonoBehaviour
    {      
        private float horizontal;
        private float veritcal;
        internal Vector2 direction;
        internal bool isRollPressed = false;
        internal bool isAlternativePressed = false;

        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            veritcal = Input.GetAxisRaw("Vertical");
            direction = new Vector2(horizontal, veritcal);

            if (Input.GetButtonDown("Roll") && ((horizontal != 0) | (veritcal != 0)))
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
