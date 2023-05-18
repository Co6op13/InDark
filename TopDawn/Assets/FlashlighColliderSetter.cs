
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlighColliderSetter : MonoBehaviour
{
    [SerializeField] private Light2D flashlight;
    [SerializeField] private EdgeCollider2D edgeCollider2D;
    [SerializeField] private float delaySet;
    [Space]
    [SerializeField] private float hTriangle;
    [SerializeField] private float aAngele;
    [SerializeField] private float hypotenuse;
    [SerializeField] private Vector3 dir;
    [SerializeField] private Transform point;

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
        hypotenuse = flashlight.pointLightOuterRadius;
        aAngele = flashlight.pointLightInnerAngle;

        hTriangle = hypotenuse * Mathf.Cos(aAngele * 0.5f);

         dir = AccessoryMetods.GetVectorFromAngle(aAngele);
        point.position = dir * hTriangle;
        Debug.DrawRay(transform.position, dir,  Color.red);
        
        //Debug.DrawLine(transform.position, dir * hypotenuse, Color.yellow);
    }
}
