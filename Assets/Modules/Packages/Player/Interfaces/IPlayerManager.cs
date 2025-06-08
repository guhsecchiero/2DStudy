using UnityEngine;

namespace Packages.Player.Interfaces
{
    public interface IPlayerManager
    {
        void HandleInput();
        void SetActive(bool isActive);
        public void SetMovementController(IMovementController movementController);
        public void SetAnimationController(IAnimationController animationController);
    }
}
