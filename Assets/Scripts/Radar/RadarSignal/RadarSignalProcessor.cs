using System.Collections.Generic;
using UnityEngine;

namespace Radar.RadarSignal
{
    public class RadarSignalProcessor : MonoBehaviour
    {
        [SerializeField] private GameObject targetIconPrefab;
        [SerializeField] private GameObject passiveObstaclePartIconPrefab;
        [SerializeField] private GameObject wayLinePrefab;

        private static readonly IDictionary<int, GameObject> WayLines = new Dictionary<int, GameObject>();
        private GameObject _targetIcons;
        private GameObject _passiveObstaclePartIcons;
        private GameObject _wayLines;

        private void Start()
        {
            _targetIcons = new GameObject
            {
                name = "TargetIcons"
            };
            
            _passiveObstaclePartIcons = new GameObject
            {
                name = "PassiveObstaclePartIcons"
            };
            
            _wayLines = new GameObject
            {
                name = "WayLines"
            };
        }

        private void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject;
            if (obj.layer == LayerMask.NameToLayer("Aircraft"))
            {
                var position = CreateIcon(obj, targetIconPrefab, _targetIcons);
                position.y += 2;
                var objId = obj.GetInstanceID();
                if (WayLines.ContainsKey(objId))
                {
                    var wayLine = WayLines[objId];
                    AddPosition(wayLine, position);
                }
                else
                {
                    var wayLine = CreateWayLine();
                    AddPosition(wayLine, position);
                    WayLines.Add(objId, wayLine);
                }
            }
            else if (obj.layer == LayerMask.NameToLayer("Clouds"))
            {
                CreateIcon(obj, passiveObstaclePartIconPrefab, _passiveObstaclePartIcons);
            }
        }

        private GameObject CreateWayLine()
        {
            return Instantiate(wayLinePrefab, _wayLines.transform, true);
        }

        private static void AddPosition(GameObject obj, Vector3 position)
        {
            var lineRenderer = obj.GetComponent<LineRenderer>();
            lineRenderer.positionCount += 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(position.x, position.y, position.z));
        }

        private static Vector3 CreateIcon(GameObject obj, GameObject iconPrefab, GameObject parent)
        {
            var position = obj.transform.position;
            CartesianToPolar(position.x, position.z, out var radius, out var angle);
            var adjustedRadius = AdjustRadius(radius);

            var icon = Instantiate(iconPrefab, parent.transform, true);
            var startPosition = new Vector3(adjustedRadius, 3f, 0f);
            var endPosition = Quaternion.Euler(0f, -angle, 0f) * startPosition;
            icon.transform.position = endPosition;
            return endPosition;
        }

        private static float AdjustRadius(float r)
        {
            return 2f * r / 3000f;
        }

        private static void CartesianToPolar(float x, float z, out float radius, out float angleInDegrees)
        {
            radius = Mathf.Sqrt(x * x + z * z);
            angleInDegrees = Mathf.Atan(z / x);
            if (x < 0)
            {
                angleInDegrees += Mathf.PI;
            }

            angleInDegrees *= Mathf.Rad2Deg;
        }
    }
}
