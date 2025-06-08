using Packages.Player.Interfaces;
using UnityEngine;

namespace Packages.Player.Managers
{
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        private IMovementController movementController;
        private IAnimationController animationController;

        private bool isActive = true;

        public void SetMovementController(IMovementController movementController)
        {
            this.movementController = movementController;
        }

        public void SetAnimationController(IAnimationController animationController)
        {
            this.animationController = animationController;
        }

        private void Awake()
        {
            if (movementController == null)
                movementController = GetComponent<IMovementController>();
            if (animationController == null)
                animationController = GetComponent<IAnimationController>();
        }

        public void HandleInput()
        {
            if (!isActive || movementController == null || animationController == null) return;

            float h = Input.GetAxisRaw("Horizontal");
            bool jumpPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetAxisRaw("Vertical") > 0.5f;

            // Always allow horizontal movement
            movementController.Move(new Vector2(h, 0));

            // Jump only once on press and only if grounded
            if (jumpPressed)
                movementController.Jump();

            // Determine animation based on vertical movement
            if (movementController.IsJumping)
            {
                animationController.Play("Jump");
            }
            else if (movementController.IsFalling)
            {
                animationController.Play("Fall");
            }
            else if (h != 0)
            {
                animationController.Play("Run");
            }
            else
            {
                animationController.Play("Idle");
                movementController.Stop();
            }
        }

        public void SetActive(bool isActive)
        {
            this.isActive = isActive;

            if (!isActive)
            {
                animationController?.Play("Idle");
                movementController?.Stop();
            }
        }
    }
}
