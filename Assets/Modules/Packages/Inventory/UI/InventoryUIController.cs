using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Packages.Inventory.Interfaces;
using Packages.Inventory.Data;

namespace Packages.Inventory.UI
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] private GameObject itemSlotPrefab;
        [SerializeField] private Transform slotContainer;

        private IInventoryManager inventoryManager;
        private readonly List<GameObject> activeSlots = new();

        private void Start()
        {
            inventoryManager = FindFirstObjectByType<MonoBehaviour>() as IInventoryManager;

            if (inventoryManager == null)
            {
                Debug.LogError("InventoryManager not found.");
                return;
            }

            RefreshUI();
        }

        public void RefreshUI()
        {
            ClearSlots();

            foreach (var item in inventoryManager.Inventory)
            {
                var slot = Instantiate(itemSlotPrefab, slotContainer);
                var text = slot.GetComponentInChildren<TextMeshProUGUI>();
                var image = slot.GetComponentInChildren<Image>();

                if (text != null) text.text = item.itemName;
                if (image != null) image.sprite = item.icon;

                activeSlots.Add(slot);
            }
        }

        private void ClearSlots()
        {
            foreach (var slot in activeSlots)
            {
                Destroy(slot);
            }

            activeSlots.Clear();
        }
    }
}
