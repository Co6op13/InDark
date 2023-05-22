using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetector : MonoBehaviour
{
    [SerializeField] private EnemyAI reciver;
    [SerializeField] private float amountLightTrigger;
    [SerializeField] private float currenAmountLight;
    [SerializeField] private float increaseAmount, decreaseAmount;
    [SerializeField] private bool isUnderLight;
    [SerializeField] private float delayCheckLight;
    [SerializeField] private int i;
    [SerializeField] public GameObject lightObject;

    public void LightON(GameObject lightObject)
    {
        isUnderLight = true;
        this.lightObject = lightObject;
    }

    public void LightOFF()
    {
        isUnderLight = false;
    }


    private void LightAmountIncrease()
    {
        if (currenAmountLight <= amountLightTrigger)
        {
            currenAmountLight += increaseAmount * Time.fixedDeltaTime;
        }
    }

    private void LightAmountDecrease()
    {
        if (currenAmountLight >= 0)
        {
            currenAmountLight -= decreaseAmount * Time.fixedDeltaTime;
        }
    }

    //private IEnumerator CheckLight()
    //{
    //    while (currenAmountLight > 0)
    //    {
    //        isUnderLight = false;
    //        yield return new WaitForSeconds(delayCheckLight);
    //        if (!isUnderLight)
    //            currenAmountLight -= decreaseAmount;
    //    }

    //}
    private void FixedUpdate()
    {
        if (!isUnderLight)
            LightAmountDecrease();
        else
            LightAmountIncrease();
        if (currenAmountLight >= amountLightTrigger)
        {
            Debug.Log("2");
            reciver.SetBehaviorReaactionToLight();
            gameObject.SetActive(false);
        }
    }


}
