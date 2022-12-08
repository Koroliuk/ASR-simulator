using UnityEngine;

public class RadarScript : MonoBehaviour
{
    private float waveRate = 4f;
    public GameObject wave;

    private void Start()
    {
        InvokeRepeating(nameof(CreateWave), 0.0f, waveRate);
    }

    private void CreateWave()
    {
        Instantiate(wave);
    }
}