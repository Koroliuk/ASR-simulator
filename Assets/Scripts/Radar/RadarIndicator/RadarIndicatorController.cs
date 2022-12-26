using UnityEngine;

namespace Radar.RadarIndicator
{
    public class RadarIndicatorController : MonoBehaviour
    {
        [SerializeField] private new Camera camera;

        [SerializeField] private float radius = 50f;

        [SerializeField] private GameObject azimuthLinePrefab;

        [SerializeField] private float azimuthAngleUnit = 10f;

        [SerializeField] private GameObject distanceCirclePrefab;

        [SerializeField] private float amountOfDistanceCircles = 15f;

        private void Start()
        {
            CreateAzimuthLines();
            CreateDistanceCircles(1000);
        }

        private void Update()
        {
            var currentLayerConfigurationMask = camera.cullingMask;

            if (Input.GetKeyDown(KeyCode.L))
            {
                camera.cullingMask = UpdateLayerConfigurationMask(currentLayerConfigurationMask, "DistanceCircles");
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                camera.cullingMask = UpdateLayerConfigurationMask(currentLayerConfigurationMask, "AzimuthLines");
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                camera.cullingMask = UpdateLayerConfigurationMask(currentLayerConfigurationMask, "TargetIcons");
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                camera.cullingMask = UpdateLayerConfigurationMask(currentLayerConfigurationMask, "CloudIcons");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                camera.cullingMask = UpdateLayerConfigurationMask(currentLayerConfigurationMask, "TargetWay");
            }
        }

        private void CreateAzimuthLines()
        {
            var azimuthLines = new GameObject
            {
                name = "AzimuthLines",
                transform =
                {
                    parent = gameObject.transform
                }
            };

            for (var angle = 0f; angle < 360f; angle += azimuthAngleUnit)
            {
                var azimuthLine = Instantiate(azimuthLinePrefab, azimuthLines.transform, true);
                azimuthLine.name = "AzimuthLine " + angle;

                var lineRenderer = azimuthLine.GetComponent<LineRenderer>();

                lineRenderer.positionCount = 2;

                lineRenderer.SetPosition(0, new Vector3(0f, 1f, 0f));

                var endPosition = new Vector3(radius, 1f, 0f);
                var rotatedEndPosition = Quaternion.Euler(0, angle, 0) * endPosition;

                lineRenderer.SetPosition(1, rotatedEndPosition);
            }
        }

        private void CreateDistanceCircles(int steps)
        {
            var distanceCircles = new GameObject
            {
                name = "DistanceCircles",
                transform =
                {
                    parent = gameObject.transform
                }
            };

            var distanceStep = radius / amountOfDistanceCircles;
            for (var i = 0; i < amountOfDistanceCircles; i++)
            {
                var distanceRadius = distanceStep * (i + 1);

                var distanceCircle = Instantiate(distanceCirclePrefab, distanceCircles.transform, true);
                distanceCircle.name = "DistanceCircle " + i;

                var lineRender = distanceCircle.GetComponent<LineRenderer>();
                lineRender.positionCount = steps;

                for (var currentStep = 0; currentStep < steps; currentStep++)
                {
                    var progress = (float) currentStep / steps;

                    var radian = progress * 2 * Mathf.PI;

                    var xScaled = Mathf.Cos(radian);
                    var zScaled = Mathf.Sin(radian);

                    var x = xScaled * distanceRadius;
                    var z = zScaled * distanceRadius;

                    var currentPosition = new Vector3(x, 1f, z);

                    lineRender.SetPosition(currentStep, currentPosition);
                }
            }
        }

        private static int UpdateLayerConfigurationMask(int mask, string layerName)
        {
            return mask ^ (1 << LayerMask.NameToLayer(layerName));
        }
    }
}
