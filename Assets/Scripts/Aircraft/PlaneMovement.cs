using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public struct Destination
    {
        public Destination(float x, float z)
        {
            X = x;
            Z = z;
        }

        public float X { get; }
        public float Z { get; }
    }

    private List<Destination> _destinations = new()
    {
        new Destination(70_000f, 55_000f),
        new Destination(5_000f, -75_000f),
        new Destination(60_000f, 47_000f),
        new Destination(0, 0)
    };

    private int _destinationIndex = 0;

    private float speed = 100f; // change to 100

    private void Update()
    {
        // Debug.Log(transform.position);
        var destination = _destinations[_destinationIndex];
        if (Math.Abs(transform.position.x - destination.X) < 1 && 
            Math.Abs(transform.position.z - destination.Z) < 1)
        {
            _destinationIndex = (_destinationIndex + 1) % 4;
        }
        var move = new Vector3(destination.X, transform.position.y, destination.Z);
        transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(move);
    }
}