using System.Collections.Generic;
using UnityEngine;


public class PatrolSettings : MonoBehaviour
{
    [SerializeField] private List<Transform> path;
    [SerializeField] private float viewingDistance;

    public List<Transform> Path { get => path; }
    public float ViewingDistance { get => viewingDistance; }
}
