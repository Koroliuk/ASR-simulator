using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCollisionScript : MonoBehaviour
{
    public GameObject icon;

    void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Aircraft"))
        {
            var position = obj.transform.position;
            Debug.Log(position);

            var x = position.x;
            var z = position.z;

            var r = Mathf.Sqrt(x * x + z * z);
            var degree = Mathf.Atan(z / x);
            if (x < 0)
            {
                degree += Mathf.PI;
            }
            degree *= Mathf.Rad2Deg;
            
            var rAdjusted = (float)2 * r / 3000;
            var createdIcon = Instantiate(icon);
            var startPos = new Vector3(rAdjusted, 3f, 0f);
            var endPos = Quaternion.Euler(0f, -degree, 0f) * startPos;
            createdIcon.transform.position = endPos;
        }
        else if (obj.layer == LayerMask.NameToLayer("Clouds"))
        {
            Debug.Log("Cloud");
            Debug.Log(obj.transform.position);
        }
    }
    
}
