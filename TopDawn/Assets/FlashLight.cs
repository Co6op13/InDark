using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteAlways]
[RequireComponent(typeof(RotateWeapon))]
public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light2D lightBeam;
    [SerializeField] [Range(1, 10)] private float minDistance, maxDistance;
    [Space]
    [SerializeField] [Range(0, 3)] private float coefficientInneRadius, coefficientOutrerRadius;
    [SerializeField] [Range(0, 360)] float innerRadius, outerRadius;
    [Space]
    [SerializeField] [Range(0, 100)] private float coefficienInnertAngle, coefficientOutertAngle;
    [SerializeField] [Range(0, 360)] private float innerAngle, outrerAngle;
    [Space]
    [SerializeField] [Range(0, 10)] private float intesity;
    [SerializeField] [Range(0, 10)] private float coefficientIntensity;
    [Space]
    // [SerializeField] private Light2D lightSpot;
    [SerializeField] private LayerMask surface;
    //[SerializeField] [Range(0, 3)] private float coefficientSpotRadius;
    [Space]
    [SerializeField] private float lightDistance;
    [SerializeField] private float distanceToMause;

    private RotateWeapon weapon;


    // Start is called before the first frame update
    private void Awake()
    {
        weapon = GetComponent<RotateWeapon>();
        //flashlight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        distanceToMause = GetDistanceToPoint();

        lightDistance = distanceToMause > maxDistance ? maxDistance :
              distanceToMause < minDistance ? minDistance : distanceToMause;

        SetAngle(lightDistance);
        SetIntencity(lightDistance);
        SetRadius(lightDistance);
        //IsVisibleObject.CheckDistance(transform.position, weapon.mausePosition, surface, 
        //    out float distance, out Vector2 pointLightIncidence);
        //float currentIntensyty = distanceToMause > maxDistance? 
        //    (intesity * coefficientIntensity) / maxDistance : (intesity * coefficientIntensity) / distanceToMause;

        //lightBeam.intensity = currentIntensyty;



        //lightSpot.pointLightInnerRadius = distanceToMause * coefficientInneRadius;
        //lightSpot.pointLightOuterRadius = distanceToMause * coefficientOutrerRadius;
        //lightSpot.intensity = currentIntensyty;
        //lightSpot.transform.position = pointLightIncidence;
        //lightSpot.transform.localScale = new Vector3(1f + distance * coefficientSpotRadius, 1f, 1f);
        //lightSpot.intensity = currentIntensyty;
    }

    private void SetIntencity(float distance)
    {
        lightBeam.intensity = (intesity * coefficientIntensity) / distance;
    }

    private void SetAngle(float distance)
    {
        lightBeam.pointLightInnerAngle = coefficienInnertAngle / distance * innerAngle;
        lightBeam.pointLightOuterAngle = coefficientOutertAngle / distance * outrerAngle;
        //lightBeam.pointLightOuterAngle = outer;
    }

    private void SetRadius(float distance)
    {
        lightBeam.pointLightInnerRadius = innerRadius * distance * coefficientInneRadius;

        lightBeam.pointLightOuterRadius = outerRadius * distance * coefficientOutrerRadius;

    }

    //private float GetCurrentIntencity(float distance)
    //{
    //    return (intesity * coefficientIntensity) / distance;
    //}

    private float GetDistanceToPoint()
    {
        return Vector2.Distance(transform.position, weapon.mausePosition);
    }
}