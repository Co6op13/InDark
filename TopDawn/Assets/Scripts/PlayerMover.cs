using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [Range(0f, 10f)]
    [Tooltip("The movement speed of the character when walking")]
    [SerializeField]
    private float walkSpeed;
    [Range(0f, 10f)]
    [Tooltip("The movement speed of the character when running")]
    [SerializeField]
    private float runSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isRunning = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    public void OnRunning(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        var currentSpped = isRunning ? runSpeed : walkSpeed;
        MoveDirection(moveDirection, currentSpped);
       // isRunning == true ? runSpeed = 1 :  walkSpeed = 2;
    }

    private void MoveDirection(Vector2 direction, float speed )
    {
        rb.velocity += direction * speed;
    }
}
