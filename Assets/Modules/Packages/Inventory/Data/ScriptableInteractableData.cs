using UnityEngine;

namespace Packages.Inventory.Data
{
    [CreateAssetMenu(menuName = "Inventory/Interactable Item")]
    public class ScriptableInteractableData : ScriptableObject
    {
        public string objectName;
        public Sprite icon;
        public bool isUsable;

        public InventoryItemData CreateItemData()
        {
            return new InventoryItemData
            {
                itemName = objectName,
                icon = icon,
                isUsable = isUsable
            };
        }
    }
}
