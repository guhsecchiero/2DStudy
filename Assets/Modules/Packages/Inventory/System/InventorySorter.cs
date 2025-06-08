using System.Collections.Generic;
using System.Linq;
using Packages.Inventory.Data;

namespace Packages.Inventory.Systems
{
    public static class InventorySorter
    {
        public enum SortMode
        {
            NameAscending,
            NameDescending,
            UsableOnly
        }

        public static List<InventoryItemData> Sort(List<InventoryItemData> items, SortMode mode)
        {
            return mode switch
            {
                SortMode.NameAscending => items.OrderBy(i => i.itemName).ToList(),
                SortMode.NameDescending => items.OrderByDescending(i => i.itemName).ToList(),
                SortMode.UsableOnly => items.Where(i => i.isUsable).ToList(),
                _ => items
            };
        }
    }
}
