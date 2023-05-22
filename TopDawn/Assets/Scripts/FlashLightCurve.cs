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
        SetScaleCollider();
                                            
    }

    private void SetScaleCollider()
    {
        transform.localScale = new Vector3(lightBeam.pointLightInnerAngle * XScaleColliderCurve.Evaluate(PercentDistanceOfLight),
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

    private void OnTriggerEnter2D(Collider2D collision)
    {             
        if (collision.gameObject != null && AccessoryMetods.CheckVisible(transform, collision.transform, vievedLayer))
        {
            Debug.Log(collision.name);
            collision.gameObject.GetComponent<LightDetector>().LightON(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<LightDetector>().LightOFF();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lightBeam.pointLightInnerRadius * 1.2f);
    }
}
