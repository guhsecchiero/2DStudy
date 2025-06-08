using UnityEngine;
using Packages.Core.Interfaces;
using Packages.Inventory.Managers;
using Packages.Inventory.Data;
using Packages.Inventory.Interfaces;
using UnityEngine.InputSystem;

namespace Packages.Interactions.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractableObjectComponent : MonoBehaviour
    {
        [SerializeField] private string interactionText = "Pick up";
        [SerializeField] private ScriptableInteractableData data;

        private IInteractionPromptUI promptUI;
        private bool isPlayerInRange;
        private IInventoryManager inventoryManager;

        private void Start()
        {
            promptUI = FindFirstObjectByType<MonoBehaviour>() as IInteractionPromptUI;
            inventoryManager = FindFirstObjectByType<MonoBehaviour>() as IInventoryManager;
        }

        private void Update()
        {
            if (isPlayerInRange && Keyboard.current.eKey.wasPressedThisFrame)
            {
                Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            isPlayerInRange = true;
            promptUI?.ShowPrompt($"[E] {interactionText} {data.objectName}");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            isPlayerInRange = false;
            promptUI?.HidePrompt();
        }

        private void Interact()
        {
            if (data == null || inventoryManager == null) return;

            InventoryItemData item = data.CreateItemData();
            inventoryManager.AddItem(item);

            promptUI?.HidePrompt();

            Destroy(gameObject);
        }
    }
}
