using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{

    // private List<GameObject> distanceCircleList = new();
    // private List<GameObject> azimuthLinesList = new();
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     var distanceCircles = GameObject.Find("Distance");
    //     foreach(Transform child in distanceCircles.transform)
    //     {
    //         distanceCircleList.Add(child.gameObject);
    //     }
    //
    //     var azimuthLines = GameObject.Find("AzimuthLines");
    //     foreach(Transform child in azimuthLines.transform)
    //     {
    //         azimuthLinesList.Add(child.gameObject);
    //     }
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.L))
    //     {
    //         foreach (var circle in distanceCircleList)
    //         {
    //             if (circle.layer != LayerMask.NameToLayer("Ignore"))
    //             {
    //                 circle.layer = LayerMask.NameToLayer("Ignore");
    //             }
    //             else
    //             {
    //                 circle.layer = LayerMask.NameToLayer("Minimap");
    //             }
    //         }
    //     }
    //     
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         foreach (var circle in azimuthLinesList)
    //         {
    //             if (circle.layer != LayerMask.NameToLayer("Ignore"))
    //             {
    //                 circle.layer = LayerMask.NameToLayer("Ignore");
    //             }
    //             else
    //             {
    //                 circle.layer = LayerMask.NameToLayer("Minimap");
    //             }
    //         }
    //     }
    //
    // }

    public Camera camera;

    private void Update()
    {
    
        var b = camera.cullingMask;
        if (Input.GetKeyDown(KeyCode.L))
        {
            var res = b ^ (1 << LayerMask.NameToLayer("DistanceCircles"));
            camera.cullingMask = res;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            var res = b ^ (1 << LayerMask.NameToLayer("AzimuthLines"));
            camera.cullingMask = res;
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            var res = b ^ (1 << LayerMask.NameToLayer("TargetIcons"));
            camera.cullingMask = res;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            var res = b ^ (1 << LayerMask.NameToLayer("CloudIcons"));
            camera.cullingMask = res;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            var res = b ^ (1 << LayerMask.NameToLayer("TargetWay"));
            camera.cullingMask = res;
        }
    }
    
    public static int modifyBit(int n,
        int p,
        int b)
    {
        int mask = 1 << p;
        return (n & ~mask) |
               ((b << p) & mask);
    }
}
