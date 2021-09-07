using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] private float sppedMovemetnInPatrol;
    [SerializeField] private float sppedMovemetnInAgressiv;
    [SerializeField] private int maxHP;
    [SerializeField] private int damage;
    [SerializeField] private float viewDistance;
    [SerializeField, Tooltip("distance at which it is afraid of light")] 
    private float distanceAfraidLight;
    [SerializeField] private bool isAfraidLight;

    public float ViewDistance { get => viewDistance;  }

    void Start()
    {
    }
}
