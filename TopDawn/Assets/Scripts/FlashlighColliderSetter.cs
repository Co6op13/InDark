
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlighColliderSetter : MonoBehaviour
{
    [SerializeField] private Light2D flashlight;
    [SerializeField] private Transform collider2d;
    [SerializeField] private float delaySet;
    [Space]
    [SerializeField] private AnimationCurve scaleCurve;

    private void Start()
    {
        StartCoroutine(SetColliderpoints());
    }

    private IEnumerator SetColliderpoints ()
    {
        while (gameObject)
        {
            GetPoints();
            yield return new WaitForSeconds(delaySet);
        }
        
    }

    private void GetPoints()
    {
        //hypotenuse = flashlight.pointLightOuterRadius;
        //aAngele = flashlight.pointLightInnerAngle;

        //hTriangle = hypotenuse * Mathf.Cos(aAngele * 0.5f);

        // dir = AccessoryMetods.GetVectorFromAngle(aAngele);
        //point.position = dir * hTriangle;
        //Debug.DrawRay(transform.position, dir,  Color.red);
        
        //Debug.DrawLine(transform.position, dir * hypotenuse, Color.yellow);
    }
}
