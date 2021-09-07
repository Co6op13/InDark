using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace character
{

    public class CharacterData : MonoBehaviour
    {
        internal CharacterMovement movement;
        internal CharacterInput input;

        // данные персонажа
        [SerializeField] internal int maxHP = 10;
        [SerializeField] internal int HPcurrent;
        [SerializeField] internal int maxAmmo9mm;
        [SerializeField] internal int ammo9mmCurrent;
        [SerializeField] internal float walkSpeed = 4f;
        [SerializeField] internal float runSpeed = 10f;
        [SerializeField] internal float rollSpeed = 15f;
        [SerializeField, Tooltip("Cost stamina  in units per second on running")]
        internal float runningStaminaCost = 1;
        [SerializeField, Tooltip("Delay after rolling, in units per second, that the character moves.")]
        internal float rollDelay = 0.8f;
        [SerializeField, Tooltip("Acceleration while grounded.")]
        internal float Acceleration = 75;
        [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
        internal float Deceleration = 70;
        [SerializeField] private float MaxStamina = 10f;
        [SerializeField] private float staminaCurrent;
        [SerializeField] private int maxRoadFlare = 10;
        [SerializeField] private int roadFlareCurrent;
        [SerializeField] private int maxMedicineChest = 3;
        [SerializeField] private int medicalChestCurrent;
        [SerializeField, Tooltip("Delay recovery stamina in seconds when stamina = 0")]
        internal float delayRecoveryStaminaif0 = 1f;
        [SerializeField, Tooltip("Recovery stamina in unit per seconds")]
        internal float speedRecoveryStamina = 0.5f;
        internal BoxCollider2D boxCollider2D;
        internal Animator animatorGFX;

        private void Start()
        {
            input = gameObject.GetComponent<CharacterInput>();
            movement = gameObject.GetComponent<CharacterMovement>();
            animatorGFX = gameObject.transform.GetComponentInChildren<Animator>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            HPcurrent = maxHP;
            staminaCurrent = MaxStamina;
            roadFlareCurrent = maxRoadFlare;
            medicalChestCurrent = maxMedicineChest;
            StartCoroutine(RecoveryStamina());
        }

        private IEnumerator RecoveryStamina() ///надо тестировать
        {
            yield return new WaitForSeconds(delayRecoveryStaminaif0);
            Debug.Log("Corutine не реализована");
            //while (true)
            //{
            //    if (staminaCurrent == MaxStamina)
            //    {
            //        Debug.Log("test1");

            //        break;
            //    }
            //    else if (staminaCurrent == 0)
            //    {
            //        yield return new WaitForSeconds(delayRecoveryStaminaif0);
            //        Debug.Log("test2");
            //        staminaCurrent += speedRecoveryStamina;
            //    }
            //    else
            //    {
            //        Debug.Log("test3");
            //        staminaCurrent += speedRecoveryStamina;
            //    }
            //}
        }

        public void IncreaseMaxHP(int count)
        {
            maxHP += count;
        }
        public void IncreaseMaxStamina(int count)
        {
            MaxStamina += count;
        }

        public void IncreaseInventory()
        {
            Debug.Log("Не реализованно");
        }
        public void GetDamage(int damage)
        {
            if (HPcurrent - damage > 0)
            {
                HPcurrent -= damage;
            }
            else
                CharacterDie();
        }

        public void GetHeal(int heal)
        {
            if (HPcurrent + heal < maxHP)
            {
                HPcurrent += heal;
            }
            else
                HPcurrent = maxHP;
        }

        public void GetAmmo9MM(int ammo)
        {
            if (ammo9mmCurrent + ammo < maxAmmo9mm)
            {
                ammo9mmCurrent += ammo;
            }
            else
                ammo9mmCurrent = maxHP;

        }

        public int ReloadAmmo9mm(int ammoInClip)
        {
            if (ammo9mmCurrent - ammoInClip > 0)
            {
                ammo9mmCurrent -= ammoInClip;
                return ammoInClip;
            }
            else
            {
                int temp = ammo9mmCurrent;
                ammo9mmCurrent = 0;

                return temp;
            }
        }

        public bool UseRoadFlare()
        {
            if (roadFlareCurrent - 1 >= 0)
            {
                roadFlareCurrent -= 1;
                return true;
            }
            else
                return false;
        }

        void CharacterDie()
        {
            Debug.Log("CharacterDie");
        }
    }
}