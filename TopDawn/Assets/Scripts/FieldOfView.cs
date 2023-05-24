using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AlerState
{
    Peaceful,
    Intrigued,
    Alerting
}
public class FieldOfView : MonoBehaviour
{
    public float fov;
    public AlerState alerState;
    [Range(0, 100)] public float alertLavel, maxAlertlavel;
    [Range(0,10)] public float increaseeAlertlavel, decreaseAlertLavel;
    [SerializeField] private LayerMask layerTarget, layerTargetAndObstacle;

    private void Awake()
    {
        alerState = AlerState.Peaceful;
        alertLavel = 0;
    }

    private void FixedUpdate()
    {
        bool playerInFov = false;
        Collider2D[] targetsInFOV = Physics2D.OverlapCircleAll(
            transform.position,
            fov, layerTarget);
        foreach (var col in targetsInFOV)
        {
            if (targetsInFOV != null)
            {
                 playerInFov = AccessoryMetods.CheckVisible(
                    transform.position,
                    col.transform.position,
                    layerTargetAndObstacle);
                break;
            }
        }
        UpdateAlertStage(playerInFov);
    }

    private void UpdateAlertStage(bool playerInFOV)
    {
        switch (alerState)
        {
            case AlerState.Peaceful:
                if (playerInFOV)
                    alerState = AlerState.Intrigued;
                break;
            case AlerState.Intrigued:
                if (playerInFOV)
                {
                    alertLavel += increaseeAlertlavel;
                    if (alertLavel >= maxAlertlavel)
                        alerState = AlerState.Alerting;
                }
                else
                {
                    alertLavel -= decreaseAlertLavel;
                    if (alertLavel <= 0f)
                        alerState = AlerState.Peaceful;
                }
                break;
            case AlerState.Alerting: 
                {
                    if (!playerInFOV)
                        alerState = AlerState.Intrigued;
                }
                break;

        }

    }
}
