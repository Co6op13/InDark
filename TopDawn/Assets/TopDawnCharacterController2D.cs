using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDawnCharacter2D
{
    //[RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerStats))]
    public class TopDawnCharacterController2D : MonoBehaviour
    {
        private Vector2 movementDirection = Vector2.zero;
        private Rigidbody2D rb;
        private PlayerStats stats;

        private void Awake()
        {
            stats = GetComponent<PlayerStats>();
            rb = GetComponent<Rigidbody2D>();
        }


        
    }
}
