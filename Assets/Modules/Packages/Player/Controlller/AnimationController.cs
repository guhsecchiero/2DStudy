using Packages.Player.Interfaces;
using Packages.Player.Components;
using Packages.Player.Data;
using UnityEngine;
using System.Collections;

namespace Packages.Player.Controllers
{
    public class AnimationController : MonoBehaviour, IAnimationController
    {
        [SerializeField] private RuntimeAnimatorController animatorController;
        [SerializeField] private AnimationComponent animationComponent;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            if (animatorController != null)
            {
                animator.runtimeAnimatorController = animatorController;
            }
        }

        public void Play(string animationName)
        {
            animator.Play(animationName);
        }

        public void Stop()
        {
            animator.Play("Idle"); // or a defined "None" state
        }
    }
}
