using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
        
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private float speed = 12f;
        [SerializeField] private float jumpHeight = 3f;

        private const float Gravity = -9.81f * 2;

        private Vector3 _velocity;
        private bool _isGrounded;
    
        private void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
        
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var motion = transform.right * x + transform.forward * z;
            controller.Move(motion * (speed * Time.deltaTime));

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
            }

            _velocity.y += Gravity * Time.deltaTime;
            controller.Move(_velocity * Time.deltaTime);
        }
    }
}
