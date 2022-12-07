using System;
using UnityEngine;

public class RadarScript : MonoBehaviour
{
    public GameObject wave;

    private void Start()
    {
        InvokeRepeating(nameof(CreateWave), 0.0f, 2f);
    }

    private void CreateWave()
    {
        Instantiate(wave);
    }
}