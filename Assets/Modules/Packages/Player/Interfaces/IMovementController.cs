using UnityEngine;

namespace Packages.Player.Interfaces
{
    public interface IMovementController
    {
        void Move(Vector2 direction);
        void Jump();
        void Stop();

        bool IsGrounded { get; }
        bool IsJumping { get; }
        bool IsFalling { get; }

    }
}
