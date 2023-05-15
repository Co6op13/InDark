using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IsVisibleObject
{
    public static bool CheckVisible(Transform from, Transform target, float distance, LayerMask mask)
    {
        bool result = false;
        RaycastHit2D hit = Physics2D.Linecast(from.position, target.position, mask);
        if (hit.collider != null && Vector2.Distance(from.position, target.position) < distance)
        {
            if (hit.collider.gameObject == target.gameObject)
            {

                Debug.DrawLine(from.position, target.position);
                result = true;
            }
        }
        return result;
    }

    public static bool CheckVisible(Vector2 from, Vector2 target, LayerMask mask)
    {
        bool result = false;
        RaycastHit2D hit = Physics2D.Linecast(from, target, mask);
        if (hit.collider != null)
        {
            Debug.DrawLine(from, target);
            result = true;
        }
        return result;
    }
}
