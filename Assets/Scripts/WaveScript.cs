using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    [SerializeField]
    private int maxScale = 70;
    
    [SerializeField]
    public float waveSpeed = 0.6f;
    
    [SerializeField]
    public GameObject minimapIcon;
    
    private readonly List<GameObject> _createdIcons = new();
    
    private void FixedUpdate()
    {
        if (transform.localScale.x < maxScale) 
        { 
            transform.localScale += new Vector3(waveSpeed, waveSpeed, waveSpeed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        if (obj.layer == LayerMask.NameToLayer("Aircraft"))
        {
            var icon = Instantiate(minimapIcon);
            var pos = obj.transform.position;
            icon.transform.position = pos;
            _createdIcons.Add(icon);
        }
        else if (obj.layer == LayerMask.NameToLayer("Minimap"))
        {
            if (!_createdIcons.Contains(obj))
            {
                obj.layer = LayerMask.NameToLayer("Ignore");
            }
        }
    }
}

