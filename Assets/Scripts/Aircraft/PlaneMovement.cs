using System;
using UnityEngine;

namespace Aircraft
{
    public class PlaneMovement : MonoBehaviour
    {
        [SerializeField] private Vector3[] destinationPoints = Array.Empty<Vector3>();
        [SerializeField] private float speed = 100f;
        
        private int _destinationIndex;
        
        
        private void Update()
        {
            if (destinationPoints.Length > 0)
            {
                var destination = destinationPoints[_destinationIndex];
                if (Math.Abs(transform.position.x - destination.x) < 1 && Math.Abs(transform.position.z - destination.z) < 1)
                {
                    _destinationIndex = (_destinationIndex + 1) % destinationPoints.Length;
                }
                
                var move = new Vector3(destination.x, destination.y, destination.z);
                transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(move);
            }
        }
    }
}
