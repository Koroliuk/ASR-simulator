using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject minimapIcon;
    private Dictionary<GameObject, GameObject> _aircraft2Minimap = new Dictionary<GameObject, GameObject>();
    
    private void FixedUpdate()
    {
        if (transform.localScale.x < 8) 
        { 
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Aircraft"))
        {
            var aircraft = other.gameObject;
            if (!_aircraft2Minimap.ContainsKey(aircraft))
            {
                var obj = Instantiate(minimapIcon);
                var pos = aircraft.transform.position;
                pos.y = 0;
                obj.transform.position = pos;
                _aircraft2Minimap.Add(aircraft, obj);
            }
            else
            {
                var obj = _aircraft2Minimap[aircraft];
                var pos = aircraft.transform.position;
                pos.y = 0;
                obj.transform.position = pos;
                _aircraft2Minimap.Add(aircraft, obj);
            }
            // Debug.Log("Aircraft");
            // Debug.Log(other.gameObject.transform.position);
        }
    }
}

