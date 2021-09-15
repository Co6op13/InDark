using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Player player;
        private Animator animatorGFX;
        private string currentAnimaton;
        //Animation States
        const string CHARACTER_IDLE = "CharacterIdle";
        const string CHARACTER_RUN = "CharacterRun";
        const string CHARACTER_WALK = "CharacterWalk";
        const string CHARACTER_ROLL = "CharacterRoll";

        private void Awake()
        {
            player = gameObject.GetComponent<Player>();
            animatorGFX = gameObject.transform.GetComponentInChildren<Animator>();
        }

        void Update()
        {

            if (player.isRoll)
            {
                Debug.Log("anim roll");
                ChangeAnimationState(CHARACTER_ROLL);
            }
            else if (player.input.direction != Vector2.zero)
            {
                if (player.input.isAlternativePressed)
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