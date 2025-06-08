using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Packages.Inventory.Data;

namespace Packages.Inventory.Services
{
    public class InventorySaveSystem
    {
        private const string SaveFile = "inventory.json";

        public void SaveInventory(List<InventoryItemData> items)
        {
            InventorySaveData data = new InventorySaveData();

            foreach (var item in items)
                data.savedItemNames.Add(item.itemName);

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(GetSavePath(), json);

            Debug.Log("Inventory saved");
        }

        public List<string> LoadSavedItemNames()
        {
            if (!File.Exists(GetSavePath()))
                return new List<string>();

            string json = File.ReadAllText(GetSavePath());
            InventorySaveData data = JsonUtility.FromJson<InventorySaveData>(json);
            return data.savedItemNames;
        }

        private string GetSavePath()
        {
            return Path.Combine(Application.persistentDataPath, SaveFile);
        }
    }
}
