using System;
using System.Collections.Generic;

namespace Packages.Inventory.Data
{
    [Serializable]
    public class InventorySaveData
    {
        public List<string> savedItemNames = new();
    }
}
