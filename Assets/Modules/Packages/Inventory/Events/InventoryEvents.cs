using System;
using Packages.Inventory.Data;

namespace Packages.Inventory.Events
{
    public static class InventoryEvents
    {
        public static Action<InventoryItemData> OnItemAdded;
        public static Action<InventoryItemData> OnItemRemoved;
        public static Action OnInventoryUpdated;
    }
}
