using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{

    private void OnSceneGUI()
    {
        FieldOfView currentFOV = (FieldOfView)target;

        Color c = Color.green;
        if(currentFOV.alerState == AlerState.Intrigued)
        {
            c = Color.Lerp(Color.green, Color.red, currentFOV.alertLavel * 0.01f);
        }
        else if  ( currentFOV.alerState == AlerState.Alerting)
        {
            c = Color.red;
        }
        Handles.color = new Color(c.r, c.g, c.b, 0.1f);
        Handles.DrawSolidDisc(
            currentFOV.transform.position,
            currentFOV.transform.forward,
            currentFOV.fov);

        Handles.color = c;
        currentFOV.fov = Handles.ScaleValueHandle(
            currentFOV.fov,
            currentFOV.transform.position + currentFOV.transform.right * currentFOV.fov,
           currentFOV.transform.rotation,
           3,
           Handles.SphereHandleCap,
           1);
    }


}
