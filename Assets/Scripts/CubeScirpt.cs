using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScirpt : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MovePlayer()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var direction = new Vector3(horizontal, 0f, vertical);
        var moveVector = transform.TransformDirection(direction) * speed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
    }

    private void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && GroundedCheck())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private bool GroundedCheck()
    {
        return Physics.CheckSphere(groundCheck.position, 0.5f, groundLayers, QueryTriggerInteraction.Ignore);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
