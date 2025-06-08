using UnityEngine;
using System.Collections.Generic;
using Packages.Inventory.Data;
using Packages.Inventory.Interfaces;
using Packages.Inventory.Services;

namespace Packages.Inventory.Managers
{
    public class InventoryManager : MonoBehaviour, IInventoryManager
    {
        [SerializeField] private List<ScriptableInteractableData> itemDatabase;

        private readonly List<InventoryItemData> inventoryItems = new();
        private InventorySaveSystem saveSystem;

        public IReadOnlyList<InventoryItemData> Inventory => inventoryItems;

        private void Awake()
        {
            saveSystem = new InventorySaveSystem();
            LoadInventory();
        }

        public void AddItem(InventoryItemData item)
        {
            inventoryItems.Add(item);
        }

        public void UseItem(InventoryItemData item)
        {
            inventoryItems.Remove(item);
        }

        public void SaveInventory()
        {
            saveSystem.SaveInventory(inventoryItems);
        }

        public void LoadInventory()
        {
            var savedNames = saveSystem.LoadSavedItemNames();
            foreach (var name in savedNames)
            {
                var match = itemDatabase.Find(x => x.objectName == name);
                if (match != null)
                {
                    inventoryItems.Add(match.CreateItemData());
                }
                else
                {
                    Debug.LogWarning($"Saved item '{name}' not found in database.");
                }
            }
        }
    }
}
