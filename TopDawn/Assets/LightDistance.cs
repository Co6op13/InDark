using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(RotateWeapon))]
public class LightDistance : MonoBehaviour
{
    [SerializeField] [Range(1, 20)] float inner, outer;
    [SerializeField] private Light2D flashlight;
    private RotateWeapon weapon;

    
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<RotateWeapon>();
        //flashlight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        flashlight.pointLightInnerRadius = inner;
        flashlight.pointLightOuterRadius = outer;


    }
}
