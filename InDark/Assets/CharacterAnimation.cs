using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        private CharacterData character;
       [SerializeField]  private Animator animatorGFX;
        private string currentAnimaton;
        //Animation States
        const string CHARACTER_IDLE = "CharacterIdle";
        const string CHARACTER_RUN = "CharacterRun";
        const string CHARACTER_WALK = "CharacterWalk";
        const string CHARACTER_ROLL = "CharacterRoll";
        // Start is called before the first frame update
        private void Awake()
        {
            character = gameObject.GetComponent<CharacterData>();
            animatorGFX = gameObject.transform.GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
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