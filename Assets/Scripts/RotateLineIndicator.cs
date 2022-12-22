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

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Icon"))
        {
            Debug.Log(obj.tag);
            if (obj.CompareTag("Untagged"))
            {
                obj.tag = "Finish";
            }
            else
            {
                obj.layer = LayerMask.NameToLayer("Ignore");
                Destroy(obj);
            }
        }    
    }
}
