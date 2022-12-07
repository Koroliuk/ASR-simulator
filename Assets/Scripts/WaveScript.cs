using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject minimapIcon;
    private List<GameObject> list = new();
    
    private void FixedUpdate()
    {
        if (transform.localScale.x < 12) 
        { 
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            Destroy(gameObject);
            // foreach (var icon in list)
            // {
            //     Destroy(icon);
            // }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Aircraft"))
        {
            var aircraft = other.gameObject;
            var obj = Instantiate(minimapIcon);
            var pos = aircraft.transform.position;
            pos.y = 0;
            obj.transform.position = pos;
            list.Add(obj);
            // var aircraft = other.gameObject;
            // var id = aircraft.GetInstanceID();
            // if (!_aircraft2Minimap.ContainsKey(id))
            // {
            //     var obj = Instantiate(minimapIcon);
            //     var pos = aircraft.transform.position;
            //     pos.y = 0;
            //     obj.transform.position = pos;
            //     _aircraft2Minimap.TryAdd(id, obj);
            // }
            // else
            // {
            //     var obj = _aircraft2Minimap[id];
            //     _aircraft2Minimap.TryRemove(id, out obj);
            //     Destroy(obj.gameObject);
            //     var pos = aircraft.transform.position;
            //     pos.y = 0;
            //     obj.transform.position = pos;
            //     _aircraft2Minimap.TryAdd(id, obj);
            // }
            // Debug.Log("Aircraft");
            // Debug.Log(other.gameObject.transform.position);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Minimap"))
        {
            if (!list.Contains(other.gameObject))
            {
                other.gameObject.layer = LayerMask.NameToLayer("Ignore");
            }
            // Destroy(other.gameObject);
            // Destroy(other);
        }
    }
}

