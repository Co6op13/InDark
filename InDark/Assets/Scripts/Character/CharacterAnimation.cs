using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        private CharacterData character;
        private Animator animatorGFX;
        private string currentAnimaton;
        //Animation States
        const string CHARACTER_IDLE = "CharacterIdle";
        const string CHARACTER_RUN = "CharacterRun";
        const string CHARACTER_WALK = "CharacterWalk";
        const string CHARACTER_ROLL = "CharacterRoll";

        private void Awake()
        {
            character = gameObject.GetComponent<CharacterData>();
            animatorGFX = gameObject.transform.GetComponentInChildren<Animator>();
        }

        void Update()
        {

            if (character.movement.isRoll)
            {
                Debug.Log("anim roll");
                ChangeAnimationState(CHARACTER_ROLL);
            }
            else if (character.input.moveInputX != 0 || character.input.moveInputY != 0)
            {
                if (character.input.isAlternativePressed)
                    ChangeAnimationState(CHARACTER_RUN);
                else
                    ChangeAnimationState(CHARACTER_WALK);
            }
            else
                ChangeAnimationState(CHARACTER_IDLE);
        }
      
        void ChangeAnimationState(string newAnimation)
        {
            if (currentAnimaton == newAnimation) return;
            animatorGFX.Play(newAnimation);
            currentAnimaton = newAnimation;
        }
    }
}