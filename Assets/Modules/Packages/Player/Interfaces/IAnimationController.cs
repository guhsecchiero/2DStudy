using UnityEngine;

namespace Packages.Player.Interfaces
{
    public interface IAnimationController
    {
        void Play(string animationName);
        void Stop();
    }
}
