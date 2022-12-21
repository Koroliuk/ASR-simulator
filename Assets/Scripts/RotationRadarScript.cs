using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRadarScript : MonoBehaviour
{
    public float speed = 10000;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
    
    // void OnTriggerEnter(Collider other)
    // {
    //     var obj = other.gameObject;
    //     if (obj.layer == LayerMask.NameToLayer("Aircraft"))
    //     {
    //         Debug.Log(obj.transform.position);
    //     }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     var obj = collision.gameObject;
    //     if (obj.layer == LayerMask.NameToLayer("Aircraft"))
    //     {
    //         Debug.Log(obj.transform.position);
    //     }
    // }
}