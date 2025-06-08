using Packages.Player.Interfaces;
using UnityEngine;

namespace Packages.Player.Controllers
{
    public class MovementController : MonoBehaviour, IMovementController
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.1f;

        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        private Vector2 moveInput;

        public bool IsGrounded { get; private set; }
        public bool IsJumping => rb.linearVelocity.y > 0.1f;
        public bool IsFalling => rb.linearVelocity.y < -0.1f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }

        public void Move(Vector2 direction)
        {
            moveInput.x = direction.x;

            // Flip sprite based on horizontal direction
            if (direction.x != 0)
                spriteRenderer.flipX = direction.x < 0;
        }

        public void Jump()
        {
            if (IsGrounded)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        public void Stop()
        {
            moveInput = Vector2.zero;
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }
}