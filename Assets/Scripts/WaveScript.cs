using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private const int MaxScale = 70;
    public GameObject minimapIcon;
    private readonly List<GameObject> _createdIcons = new();
    
    private void FixedUpdate()
    {
        if (transform.localScale.x < MaxScale) 
        { 
            transform.localScale += new Vector3(0.6f, 0.6f, 0.6f);
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

