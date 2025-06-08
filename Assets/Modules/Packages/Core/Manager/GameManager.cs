using UnityEngine;
using Packages.Player.Interfaces;
using Packages.Player.Managers;
using Packages.Player.Controllers;
using Packages.Core.Interfaces;

namespace Packages.Core.Managers
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [Header("Player Prefab")]
        [SerializeField] private GameObject playerPrefab;

        private IPlayerManager playerManager;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            Tick();
        }

        public void Initialize()
        {
            if (playerPrefab == null)
            {
                Debug.LogError("Player prefab not assigned in GameManager!");
                return;
            }

            var playerGO = Instantiate(playerPrefab);
            var manager = playerGO.GetComponent<IPlayerManager>();
            var movement = playerGO.GetComponent<MovementController>();
            var animation = playerGO.GetComponentInChildren<AnimationController>();

            if (manager == null || movement == null || animation == null)
            {
                Debug.LogError("Missing components on player prefab.");
                return;
            }

            manager.SetMovementController(movement);
            manager.SetAnimationController(animation);
            playerManager = manager;
        }

        public void Tick()
        {
            playerManager?.HandleInput();
        }
    }
}
