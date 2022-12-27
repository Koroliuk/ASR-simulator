using UnityEngine;

namespace PassiveObstacles
{
    public class CloudGroupMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 direction = new (1.7f, 0f, -1f);
        [SerializeField] private float speed = 100f;

        private void Update()
        {
            transform.position += direction.normalized * (Time.deltaTime * speed);

            var position = gameObject.transform.position;
            var r = 100_000f * Mathf.Sqrt(2) / 2; 
            if (position.x * position.x + position.z * position.z > r * r)
            {
                transform.position = new Vector3(-position.x, position.y, -position.z);
            }
        }
    }
}
