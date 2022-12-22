using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCircleScript : MonoBehaviour
{
    public LineRenderer circleRender;
    [SerializeField]
    public float radius;
    
    private void Start()
    {
        DrawCircle(1000, radius);
    }
    
    private void DrawCircle(int steps, float radius)
    {
        circleRender.positionCount = steps;

        for (var currentStep = 0; currentStep < steps; currentStep++)
        {
            var circumferenceProgress = (float) currentStep / steps;

            var currentRadian = circumferenceProgress * 2 * Mathf.PI;

            var xScaled = Mathf.Cos(currentRadian);
            var zScaled = Mathf.Sin(currentRadian);

            var x = xScaled * radius;
            var z = zScaled * radius;

            var currentPosition = new Vector3(x, 1f, z);
            
            circleRender.SetPosition(currentStep, currentPosition);
        }
    }
}
