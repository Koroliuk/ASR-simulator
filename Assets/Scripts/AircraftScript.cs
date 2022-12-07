using System;
using UnityEngine;
using Random = System.Random;


public class AircraftScript : MonoBehaviour
{
    private float _speed = 0.5f;
    private State _state = State.Start;
    private Vector3 _destination;
    
    private void FixedUpdate()
    {
        var currPosition = gameObject.transform.position;
        if (State.Start.Equals(_state))
        {
            _destination = GenerateRandomDestination(currPosition);
            _state = State.Moving;
        }
        else if (Math.Abs(currPosition.x - _destination.x) < 0.01 &&
                 Math.Abs(currPosition.y - _destination.y) < 0.01 &&
                 Math.Abs(currPosition.z - _destination.z) < 0.01)
        {
            _state = State.Start;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
        }
    }

    private static Vector3 GenerateRandomDestination(Vector3 currentPosition)
    {
        var x = currentPosition.x;
        var y = currentPosition.y;
        var z = currentPosition.z;
        while (!(Math.Abs(currentPosition.y-y) < 0.5 && y > 0.5 && x*x + z*z > 0.25 && 
                 (x-currentPosition.x)*(x-currentPosition.x) + (z-currentPosition.z)*(z-currentPosition.z) > 0.25))
        {
            x = GenerateRandomNumber();
            y = GenerateRandomNumber();
            z = GenerateRandomNumber();
        }

        return new Vector3(x, y, z);
    }

    private static float GenerateRandomNumber()
    {
        var random = new Random();
        return (float) ((4 * 2) * random.NextDouble() + (-4));
    }
    
    private enum State
    {
        Start,
        Moving
    }
}