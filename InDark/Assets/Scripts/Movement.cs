using UnityEditor;
using UnityEngine;


public class Movement : MonoBehaviour
{   
    public void MovePosition(Rigidbody2D rigidbody, Vector2 direction, float speed)
    {
        direction = direction * speed * Time.deltaTime;
        rigidbody.MovePosition((rigidbody.position + direction));
    }

    public void Roll(Rigidbody2D rigidbody, Vector2 direction, float range)
    {
        Debug.Log("не реализованно");
    }

    public void Jump(Rigidbody2D rigidbody, Vector2 direction, float range)
    {
        Debug.Log("не реализованно");
    }
}