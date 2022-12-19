using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speed = 100;
    
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
