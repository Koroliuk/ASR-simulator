using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateLineIndicator : MonoBehaviour
{
    public Collider collider;
    public LineRenderer lineRenderer;
    public float speed = 10;
    // public GameObject wayLine;
    
    void Start()
    {
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, new Vector3(0f, 1f, 0f));

        var move = new Vector3(50, 1f, 0f);
        lineRenderer.SetPosition(1, move);
    }
    
    void Update()
    {
        var myVector = Quaternion.Euler(0, speed * Time.deltaTime, 0) * lineRenderer.GetPosition(1);
        
        lineRenderer.SetPosition(0, new Vector3(0f, 1f, 0f));
        lineRenderer.SetPosition(1, myVector);

        collider.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), speed * Time.deltaTime);
    }

    private struct Point
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }

    }

    private static IDictionary<int, GameObject> ways = new Dictionary<int, GameObject>();

    public static IDictionary<int, GameObject> Ways
    {
        get => ways;
        set => ways = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        var id = obj.GetInstanceID();
        if (obj.layer == LayerMask.NameToLayer("TargetIcons") || obj.layer == LayerMask.NameToLayer("CloudIcons"))
        {
            Debug.Log(obj.tag);
            if (obj.CompareTag("Untagged"))
            {
                obj.tag = "Finish";
            }
            else
            {
                RadarCollisionScript.IconId2PlaneId.Remove(obj.GetInstanceID());
                obj.layer = LayerMask.NameToLayer("Ignore");
                Destroy(obj);
            }
        }    
    }
}
