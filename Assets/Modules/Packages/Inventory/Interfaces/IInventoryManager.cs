using Packages.Inventory.Data;
using System.Collections.Generic;

namespace Packages.Inventory.Interfaces
{
    public interface IInventoryManager
    {
        void AddItem(InventoryItemData item);
        void UseItem(InventoryItemData item);
        void SaveInventory();
        IReadOnlyList<InventoryItemData> Inventory { get; }
    }
}
