using UnityEngine;

namespace RadarIndicator
{
    public class RotatingRadarSignalController : MonoBehaviour
    {
        [SerializeField]
        private new Collider collider;
        
        [SerializeField]
        private LineRenderer lineRenderer;
        
        [SerializeField]
        private float speed = 10f;
        
        [SerializeField]
        private float radius = 50f;

        private readonly Vector3 _startPosition = new(0f, 1f, 0f);

        private void Start()
        {
            lineRenderer.positionCount = 2;

            lineRenderer.SetPosition(0, _startPosition);

            var endPosition = new Vector3(radius, 1f, 0f);
            
            lineRenderer.SetPosition(1, endPosition);
        }

        private void Update()
        {
            var currPosition = lineRenderer.GetPosition(1);
            var endPosition = Quaternion.Euler(0, speed * Time.deltaTime, 0) * currPosition;
        
            lineRenderer.SetPosition(0, _startPosition);
            lineRenderer.SetPosition(1, endPosition);

            collider.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), speed * Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if (obj.layer == LayerMask.NameToLayer("TargetIcons") || obj.layer == LayerMask.NameToLayer("CloudIcons"))
            {
                if (obj.CompareTag("Untagged"))
                {
                    obj.tag = "Finish";
                }
                else
                {
                    RadarCollisionScript.IconId2PlaneId.Remove(obj.GetInstanceID());
                    obj.layer = LayerMask.NameToLayer("Ignore");
                    Destroy(obj);
                }
            }    
        }
    }
}
