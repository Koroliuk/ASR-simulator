using UnityEngine;

namespace Radar.RadarSignal
{
    public class RadarSignalRotation : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
    
        private void Update()
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}
