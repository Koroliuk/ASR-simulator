using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCollisionScript : MonoBehaviour
{
    public GameObject icon;
    public GameObject cloudIcon;

    private static IDictionary<int, int> iconId2PlaneId = new Dictionary<int, int>();

    private static IDictionary<int, GameObject> ways = new Dictionary<int, GameObject>();

    public static IDictionary<int, GameObject> Ways => ways;

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

            var rAdjusted = (float) 2 * r / 3000;
            var createdIcon = Instantiate(icon);
            var startPos = new Vector3(rAdjusted, 3f, 0f);
            var endPos = Quaternion.Euler(0f, -degree, 0f) * startPos;
            createdIcon.transform.position = endPos;

            iconId2PlaneId.Add(createdIcon.GetInstanceID(), obj.GetInstanceID());
            if (Ways.ContainsKey(obj.GetInstanceID()))
            {
                var gameObj = Ways[obj.GetInstanceID()];
                gameObj.layer = LayerMask.NameToLayer("TargetWay");
                var lineRenderer = gameObj.GetComponent<LineRenderer>();

                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(endPos.x, endPos.y, endPos.z));
            }
            else
            {
                var newGameObj = new GameObject();
                newGameObj.layer = LayerMask.NameToLayer("TargetWay");
                var newLineRenderer = newGameObj.AddComponent<LineRenderer>();

                newLineRenderer.startWidth = 1.17f;
                newLineRenderer.endWidth = 1.17f;
                newLineRenderer.startColor = Color.cyan;
                newLineRenderer.endColor = Color.cyan;

                var yourMaterial = (Material) Resources.Load("Crcle123", typeof(Material));
                newLineRenderer.material = yourMaterial;

                newLineRenderer.positionCount = 1;
                newLineRenderer.SetPosition(0, new Vector3(endPos.x, endPos.y, endPos.z));

                Ways.Add(obj.GetInstanceID(), newGameObj);
            }
        }
        else if (obj.layer == LayerMask.NameToLayer("Clouds"))
        {
            Debug.Log("Cloud");
            Debug.Log(obj.transform.position);
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

            var rAdjusted = (float) 2 * r / 3000;
            var createdIcon = Instantiate(cloudIcon);
            var startPos = new Vector3(rAdjusted, 3f, 0f);
            var endPos = Quaternion.Euler(0f, -degree, 0f) * startPos;
            createdIcon.transform.position = endPos;
        }
    }

    public static IDictionary<int, int> IconId2PlaneId
    {
        get => iconId2PlaneId;
        set => iconId2PlaneId = value;
    }
}