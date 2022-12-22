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

            // var x = obj.transform.position.x;
            // var z = -obj.transform.position.z;
            // var r = Mathf.Sqrt(x * x + z * z);
            // var degree = Mathf.Atan2(x, z);
            // // var degree = 180+Mathf.Atan(y / x) * 57.2958f;
            //
            
            var rAdjusted = (float)2 * r / 3000;
            var createdIcon = Instantiate(icon);
            var startPos = new Vector3(rAdjusted, 3f, 0f);
            var endPos = Quaternion.Euler(0f, -degree, 0f) * startPos;
            createdIcon.transform.position = endPos;
        }
    }

    private static void CartesianToSpherical(Vector3 cartCoords, out float outRadius, out float outPolar)
    {
        if (cartCoords.x == 0)
        {
            cartCoords.x = Mathf.Epsilon;   
        }
        outRadius = Mathf.Sqrt((cartCoords.x * cartCoords.x)
                               + (cartCoords.y * cartCoords.y)
                               + (cartCoords.z * cartCoords.z));
        outPolar = Mathf.Atan(cartCoords.z / cartCoords.x);
        if (cartCoords.x < 0)
            outPolar += Mathf.PI;
    }
    
}
