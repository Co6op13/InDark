using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Falschfeuer : MonoBehaviour
{
    [SerializeField] [Range (0,2)] private float minIntencyty, maxIntencyty;
    [SerializeField] [Range(0, 2)] private float minInnerRadius, maxInnerRadius;
    [SerializeField] [Range(0, 20)] private float minOuterRadius, maxOuterRadius;
    [SerializeField] private float lifeTime, decaylifeTime;
    [SerializeField] private float ratioLerp;
    [SerializeField] [Range(0, 0.02f)] private float decay;
    private Light2D lightSpot;
    private CircleCollider2D collider2d;
    [Space]
    private float time;
    [SerializeField] private float timeHasPassed;

    void Awake()
    {
        lightSpot = GetComponent<Light2D>();
        collider2d = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(LifeTime());
        Invoke("Stop", lifeTime + decaylifeTime);
    }

    private void Stop()
    {
        StopCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        collider2d.enabled = true;
        lightSpot.enabled = true;
        timeHasPassed = 0f;
        bool check = true;
        var delayTime = Time.fixedDeltaTime * ratioLerp;

        while (check)
        {
            SetRandovVariableInLight();
            yield return new WaitForSeconds(delayTime);            
            timeHasPassed += delayTime;
            check = timeHasPassed < lifeTime ? true : false;
        }

        delayTime = Time.fixedDeltaTime * ratioLerp;
        lightSpot.intensity = maxIntencyty;
        yield return new WaitForSeconds(delayTime);
        collider2d.enabled = false;
        timeHasPassed = 0f;
        check = true;
        
        while (check)
        {
            lightSpot.intensity -= decay;
            lightSpot.pointLightOuterRadius -= decay * 10;
            yield return new WaitForSeconds(delayTime);
            timeHasPassed += delayTime;
            check = timeHasPassed < decaylifeTime ? true : false;
        }
        lightSpot.enabled = false;       
    }


    private void SetRandovVariableInLight()
    {
        lightSpot.intensity = Random.Range(minIntencyty, maxIntencyty);
        lightSpot.pointLightInnerRadius = Random.Range(minInnerRadius, maxInnerRadius);
        // lightSpot.pointLightOuterRadius = 20f;
        lightSpot.pointLightOuterRadius = Random.Range(minOuterRadius, maxOuterRadius);
    }
}
