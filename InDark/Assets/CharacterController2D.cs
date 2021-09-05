using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    private BoxCollider2D thisBoxCollider;

    private Vector2 velocity;
    private float moveInputX;
    private float moveInputY;

    private void Awake()
    {
        
        thisBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
        Muve();
        OnCollisionWall();
    }

    private void OnCollisionWall()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, thisBoxCollider.size, 0);
        foreach (Collider2D hit in hits)
        {
            if (hit == thisBoxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(thisBoxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
        }
    }


    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void Muve()
    {

        if (moveInputX != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInputX, walkAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, groundDeceleration * Time.deltaTime);
        }

        if (moveInputY != 0)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, speed * moveInputY, walkAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.y = Mathf.MoveTowards(velocity.y, 0, groundDeceleration * Time.deltaTime);
        }
    }
}
