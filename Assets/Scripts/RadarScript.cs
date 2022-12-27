using UnityEngine;

public class RadarScript : MonoBehaviour
{
    [SerializeField]
    private float waveRate = 4f;
    
    [SerializeField]
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