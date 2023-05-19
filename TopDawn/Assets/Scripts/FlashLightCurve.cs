using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLightCurve : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D collider2d;
    [SerializeField] private LayerMask vievedLayer;
    [SerializeField] public float PercentDistanceOfLight { get; private set; }
    [SerializeField] private float lightDistance;
    [SerializeField] private float distanceToMause;
    [Space]
    [SerializeField] private RotateWeapon weapon;
    [SerializeField] private Light2D lightBeam;
    [SerializeField] [Range(0, 30)] private float minDistance, maxDistance;
    [Space]
    [SerializeField] private AnimationCurve inneRadiusCurve, outrerRadiusCurve;
    [SerializeField] [Range(0, 360)] float innerRadius, outerRadius;
    [Space]
    [SerializeField] private AnimationCurve innertAngleCurve, outertAngleCurve;
    [SerializeField] [Range(0, 360)] private float innerAngle, outrerAngle;
    [Space]
    [SerializeField] private AnimationCurve intesityCurve;
    [SerializeField] [Range(0, 1f)] private float intesity;
    [Space]
    [SerializeField] private AnimationCurve XScaleColliderCurve, YScaleColliderCurve;

    //[SerializeField] private LayerMask surface;


    // Update is called once per frame
    private void FixedUpdate()
    {
        distanceToMause = GetDistanceToPoint();
        lightDistance = distanceToMause > maxDistance ? maxDistance :
              distanceToMause < minDistance ? minDistance : distanceToMause;

        PercentDistanceOfLight = (lightDistance - minDistance) / (maxDistance - minDistance);

        SetAngle(PercentDistanceOfLight);
        SetIntencity(PercentDistanceOfLight);
        SetRadius(PercentDistanceOfLight);
        transform.localScale = new Vector3(lightBeam.pointLightInnerRadius * XScaleColliderCurve.Evaluate(PercentDistanceOfLight), 
            lightBeam.pointLightInnerRadius * YScaleColliderCurve.Evaluate(PercentDistanceOfLight), 1f);
                                            
    }

    private void SetIntencity(float proc)
    {
        lightBeam.intensity = intesity * intesityCurve.Evaluate(proc);
    }

    private void SetAngle(float distance)
    {
        lightBeam.pointLightInnerAngle = innerAngle * innertAngleCurve.Evaluate(distance);
        lightBeam.pointLightOuterAngle = outrerAngle * outertAngleCurve.Evaluate(distance);
    }

    private void SetRadius(float distance)
    {
        var currentRadius = innerRadius * inneRadiusCurve.Evaluate(distance);
        lightBeam.pointLightInnerRadius = currentRadius;
        lightBeam.pointLightOuterRadius = outerRadius * outrerRadiusCurve.Evaluate(distance);
        
        //collider2d.radius = currentRadius;
    }


    private float GetDistanceToPoint()
    {
        return Vector2.Distance(transform.position, weapon.mausePosition);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var direction = (collision.transform.position - transform.position).normalized;

        float angle = transform.eulerAngles.z;
        Debug.Log(angle);

        //Vector3 angle;
        //Vector3 axis;
        
        //transform.rotation.ToAngleAxis(out angle, out axis);
        //Debug.Log("Angle: " + angle + " Axis: " + axis);

        //if ( angle < lightBeam.pointLightInnerAngle)
        //{
        //    Debug.DrawLine(transform.position, -transform.right);
        //   // Debug.DrawRay(transform.position, direction, Color.red);

        //    if (AccessoryMetods.CheckVisible(transform, collision.transform, vievedLayer))
        //    {
        //        collision.gameObject.GetComponent<IEnemyBehavior>().LightDetected();
        //    }

        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lightBeam.pointLightInnerRadius * 1.2f);
    }
}
