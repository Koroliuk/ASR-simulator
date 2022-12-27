using UnityEngine;

namespace Radar.RadarAntenna
{
    public class RadarAntennaController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private void Update()
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}
