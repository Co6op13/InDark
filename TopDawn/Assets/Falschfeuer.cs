using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Falschfeuer : MonoBehaviour
{
    [SerializeField] private Light2D lightSpot;
    [SerializeField] private CircleCollider2D collider2d;
    [SerializeField] [Range (0,10)] private float minIntencyty, maxIntencyty;
    [SerializeField] [Range(0, 10)] private float minInnerRadius, maxInnerRadius;
    [SerializeField] [Range(0, 10)] private float minOuterRadius, maxOuterRadius;
    [SerializeField] private float lifeTime, decaylifeTime;
    
    private float time;
    
    void Start()
    {
        //lightSpot = GetComponent<Light2D>();
        collider2d = GetComponent<CircleCollider2D>();
        time = Time.time + lifeTime;
        StartCoroutine(LifeTime());
    }


    private IEnumerator LifeTime()
    {
        while (time > Time.time)
        {
            lightSpot.intensity =Random.Range(minIntencyty, maxIntencyty);
            lightSpot.pointLightInnerRadius = Random.Range(minInnerRadius, maxInnerRadius);
            lightSpot.pointLightOuterAngle = Random.Range(minOuterRadius, maxOuterRadius);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        time = Time.time + decaylifeTime;
        collider2d.enabled = false;
        lightSpot.intensity = maxIntencyty;
        yield return new WaitForSeconds(Time.fixedDeltaTime * 2);
        while (time > Time.time)
        {
            lightSpot.intensity -= Time.deltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        StopCoroutine(LifeTime());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
