using UnityEngine;

public class RadarScript : MonoBehaviour
{
    public GameObject wave;
    
    private int _state;
    // private DateTime startTime;
    
    private void FixedUpdate()
    {
        if (_state == 0)
        {
            Instantiate(wave);
            _state = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (state == 1)
        // {
        //     Destroy(other.gameObject);
        //     var totalTime = DateTime.Now.Subtract(startTime).Milliseconds;
        //     Debug.Log(totalTime);
        //     state = 2;
        // }
    }
}
