using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CustomCloudGeneration : MonoBehaviour
{
    public GameObject[] Prefabs = new GameObject[0];
    
    private struct Point
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        
        public float Y { get; set; }

        public float X { get; set; }
    }

    private List<Point> spawnPoints = new()
    {
        new Point(0, 0)
    };


    struct MyStruct
    {
        public MyStruct(Point center, float radius)
        {
            Center = center;
            Radius = radius;
        }
        
        public float Radius { get; set; }

        public Point Center { get; set; }
    }
    // Start is called before the first frame update
    void Start()
    {
        var random = new Random();
        const float halflSquareSide = 10000f;
        foreach (var point in spawnPoints)
        {
            var totalS = 0f;
            var created = new List<MyStruct>();
            while ((halflSquareSide * 4 * halflSquareSide - totalS)/(halflSquareSide * halflSquareSide * 4) > 0.8)
            {
                var randomeX= 0f;
                var randomeZ=0f;
                while (true)
                {
                    randomeX = (float)((point.X-halflSquareSide) * 2 * random.NextDouble() + -1 * (point.X+halflSquareSide));
                    randomeZ = (float)((point.Y-halflSquareSide) * 2 * random.NextDouble() + -1 * (point.Y+halflSquareSide));

                    var isValid = true;
                    foreach (var myStruct in created)
                    {
                        if (Mathf.Pow(randomeX - myStruct.Center.X, 2) + Mathf.Pow(randomeZ - myStruct.Center.Y, 2) < Mathf.Pow(myStruct.Radius, 2)-1000)
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        break;
                    }
                }

                int prefabIndex = random.Next(0, Prefabs.Length);
                Console.Write(Prefabs[prefabIndex]);
                var gameObject = Instantiate(Prefabs[prefabIndex]);
                gameObject.transform.position = new Vector3(randomeX, 12000, randomeZ);
                gameObject.transform.localScale = new Vector3(300, 300, 300);
                var collider = gameObject.GetComponent<Renderer>();
                var radius = Mathf.Sqrt(Mathf.Pow(collider.bounds.extents.x, 2)+Mathf.Pow(collider.bounds.extents.z, 2));
                var mystruct = new MyStruct(new Point(collider.bounds.center.x, collider.bounds.center.z),radius);
                created.Add(mystruct);
                totalS += Mathf.PI * radius * radius;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
