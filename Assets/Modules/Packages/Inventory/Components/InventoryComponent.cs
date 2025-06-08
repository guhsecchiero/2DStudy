using UnityEngine;
using Packages.Inventory.Data;

namespace Packages.Inventory.Components
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField] private InventoryItemData itemData;

        public InventoryItemData GetItemData() => itemData;
    }
}
