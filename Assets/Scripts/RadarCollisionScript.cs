using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCollisionScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Aircraft"))
        {
            Debug.Log(obj.transform.position);
        }
    }
}
