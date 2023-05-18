using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLightCurve : MonoBehaviour
{
    [SerializeField] private float proc;
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
  
    [SerializeField] private LayerMask surface;
  
    private void Awake()
    {
       // weapon = GetComponent<RotateWeapon>();
        //flashlight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        distanceToMause = GetDistanceToPoint();
        lightDistance = distanceToMause > maxDistance ? maxDistance :
              distanceToMause < minDistance ? minDistance : distanceToMause;

        proc = (lightDistance - minDistance) / (maxDistance - minDistance) ;

        SetAngle(proc);
        SetIntencity(proc);
        SetRadius(proc);        
    }

    private void SetIntencity (float proc)
    {
        lightBeam.intensity = intesity * intesityCurve.Evaluate(proc);
    }

    private void SetAngle(float distance)
    {
        lightBeam.pointLightInnerAngle = innerAngle *  innertAngleCurve.Evaluate(distance);
        lightBeam.pointLightOuterAngle = outrerAngle * outertAngleCurve.Evaluate(distance);
    }

    private void SetRadius(float distance)
    {
        lightBeam.pointLightInnerRadius = innerRadius * inneRadiusCurve.Evaluate(distance);
        lightBeam.pointLightOuterRadius = outerRadius * outrerRadiusCurve.Evaluate(distance);
    }


    private float GetDistanceToPoint()
    {
        return Vector2.Distance(transform.position, weapon.mausePosition);
    }
}
