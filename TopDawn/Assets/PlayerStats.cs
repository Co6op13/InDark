using UnityEngine;

[System.Serializable]
internal class PlayerStats : MonoBehaviour
{
    //public StatsChangeType statsChangeType;

    [Range(0, 100)]
    [Tooltip("The max health of the character")]
    public int maxHealth;



    //public AttackConfig attackConfig;
}
