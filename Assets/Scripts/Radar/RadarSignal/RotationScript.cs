using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
