using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzimuthLineScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    [SerializeField]
    public float degree;

    public float radius = 50;
    
    private void Start()
    {
        DrawAzimuthLine();
    }
    
    private void DrawAzimuthLine()
    {
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, new Vector3(0f, 1f, 0f));

        var move = new Vector3(50, 1f, 0f);
        var myVector = Quaternion.Euler(0, degree, 0) * move;
        
        lineRenderer.SetPosition(1, myVector);
    }
}
