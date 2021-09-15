using UnityEditor;
using UnityEngine;

namespace Scripts
{
    public class HealthData :MonoBehaviour
    {
        [SerializeField] internal int maxHP;
        [SerializeField] internal int currentHP;
        [SerializeField] internal bool isAlive = true;

        private void Awake()
        {
            currentHP = maxHP;
        }
        public bool IsAlive 
        { 
            get => isAlive;
            set
            {
                if (currentHP > 0)
                    isAlive = true;
                else
                    isAlive = false;
            }
        }   

        public void GetDamage(int damage)
        {
            if (currentHP - damage >= 0)
            {
                currentHP -= damage;
            }           
        }

        public void GetHeal(int heal)
        {
            if (currentHP + heal < maxHP)
            {
                currentHP += heal;
            }
            else
                currentHP = maxHP;
        }
    }
}