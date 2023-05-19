using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateWeapon : MonoBehaviour
{
   // [SerializeField] private Transform weapon;
    [SerializeField] private Camera currenCamera;
    [SerializeField] private Rigidbody2D rb;
    public Vector2 mausePosition { get; private set; }
    public Vector2 lookDirection { get; private set;  }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMousePosition (InputAction.CallbackContext context)
    {
        mausePosition = currenCamera.ScreenToWorldPoint( context.ReadValue<Vector2>());
        lookDirection = (mausePosition - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }


}
