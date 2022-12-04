using System;
using UnityEngine;

public class RadarScript : MonoBehaviour
{
    public GameObject wave;
    
    private int state = 0;
    private DateTime startTime;
    
    private void FixedUpdate()
    {
        if (state == 0)
        {
            Instantiate(wave);
            startTime = DateTime.Now;
            state = 1;
        } else if (state == 2)
        {
            Debug.Log("New radar step");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state == 1)
        {
            Destroy(other.gameObject);
            var totalTime = DateTime.Now.Subtract(startTime).Milliseconds;
            Debug.Log(totalTime);
            state = 2;
        }
    }
}
