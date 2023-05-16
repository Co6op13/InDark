using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(RotateWeapon))]
public class FlashLight : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] float inner, outer;
    [SerializeField] private Light2D lightBeam;
    [SerializeField] [Range(0, 3)] private float coefficientIntensity;
    [SerializeField] [Range(0, 3)] private float coefficientInneRadius, coefficientOutrerRadius;
    [SerializeField] [Range(0, 3)] private float coefficientSpotRadius;
    [SerializeField] private Light2D lightSpot;
    [SerializeField] [Range(0, 3)] private float intesity;
    [SerializeField] private LayerMask surface;

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
        // = GetDistanceToPoint();
        IsVisibleObject.CheckDistance(transform.position, weapon.mausePosition, surface, 
            out float distance, out Vector2 pointLightIncidence); ;
        float currentIntensyty = (intesity * coefficientIntensity) / distance;
        lightBeam.pointLightInnerRadius = distance * coefficientInneRadius;
        lightBeam.pointLightOuterRadius = distance * coefficientOutrerRadius;
        // lightBeam.intensity = currentIntensyty;



        lightSpot.transform.position = pointLightIncidence;
        lightSpot.transform.localScale = new Vector3(1f + distance * coefficientSpotRadius, 1f, 1f);
        lightSpot.intensity = currentIntensyty;
    }

    private float GetDistanceToPoint()
    {
        return Vector2.Distance(transform.position, weapon.mausePosition);
    }
}
