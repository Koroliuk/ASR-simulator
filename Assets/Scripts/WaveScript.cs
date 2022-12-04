using System;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    [SerializeField] private int speed;

    Vector3 move = Vector3.back;
    
    void FixedUpdate()
    {
        transform.Translate(move * speed * Time.deltaTime);
        transform.localScale += new Vector3(0.01f, 0.01f, 0);
        // RaycastHit hit;
        // Ray ray = new Ray(transform.position, move);
        // Debug.DrawRay (transform.position, move, Color.black);
        // if (Physics.Raycast(ray, out hit, 1f))
        // {
        //     Debug.Log("Raycast");
        //     if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Aircraft"))
        //     {
        //         Debug.Log("Aircraft");
        //         WaveScript newObject = Instantiate(this);
        //         newObject.move = Vector3.forward;
        //     }
        //     if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Radar"))
        //     {
        //         Debug.Log("Radar");
        //         Destroy(this);
        //     }
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Aircraft"))
        {
            Debug.Log("Aircraft");
            WaveScript newObject = Instantiate(this);
            newObject.move = Vector3.forward;
        }
        // if (other.gameObject.layer == LayerMask.NameToLayer("Radar"))
        // {
        //     Debug.Log("Radar");
        //     Destroy(gameObject);
        // }
    }
}

