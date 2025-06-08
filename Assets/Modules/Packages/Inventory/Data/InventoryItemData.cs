using UnityEngine;

namespace Packages.Inventory.Data
{
    [CreateAssetMenu(menuName = "Game/Inventory Item", fileName = "NewInventoryItem")]
    public class InventoryItemData : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        [TextArea] public string description;

        public bool isUsable;
        public GameObject prefabOnUse;
    }
}
