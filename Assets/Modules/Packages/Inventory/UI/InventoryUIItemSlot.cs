using UnityEngine;
using UnityEngine.UI;
using Packages.Inventory.Data;
using Packages.Inventory.Managers;
using Packages.Inventory.Interfaces;

namespace Packages.Inventory.UI
{
    public class InventoryUIItemSlot : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMPro.TextMeshProUGUI label;
        [SerializeField] private Button useButton;

        private InventoryItemData currentItem;
        private IInventoryManager inventoryManager;

        private void Awake()
        {
            if (useButton != null)
                useButton.onClick.AddListener(OnUseClicked);

            inventoryManager = FindFirstObjectByType<InventoryManager>();
        }

        public void SetItem(InventoryItemData item)
        {
            currentItem = item;
            icon.sprite = item.icon;
            label.text = item.itemName;
            useButton.interactable = item.isUsable;
        }

        private void OnUseClicked()
        {
            inventoryManager?.UseItem(currentItem);
        }
    }
}
