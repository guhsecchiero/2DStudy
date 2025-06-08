using Packages.Core.Interfaces;
using Packages.Core.Data;
using UnityEngine;
using Packages.Inventory.Data;
using Packages.Inventory.Managers;

namespace Packages.Core.Components
{
    public class InteractableComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private InteractableData data;
        [SerializeField] private InventoryItemData itemToGive;
        private bool interacted = false;

        public void Interact()
        {
            if (interacted) return;
            interacted = true;

            InventoryManager inventory = FindFirstObjectByType<InventoryManager>();
            inventory?.AddItem(itemToGive);

            if (data.interactionSound)
                AudioSource.PlayClipAtPoint(data.interactionSound, transform.position);

            if (data.itemToGivePrefab)
                Instantiate(data.itemToGivePrefab, transform.position + Vector3.up, Quaternion.identity);
        }

        public InteractableData GetData() => data;
    }
}
