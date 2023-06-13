using UnityEngine;
using UnityEngine.UI;

namespace Features.Inventory.Logic.UI
{
    public class UiItemSlot : MonoBehaviour
    {
        [SerializeField] private Image slotBackground;
        [SerializeField] private Image spriteSlot;
        
        private InventoryItem item;

        internal void SetItem(InventoryItem inventoryItem)
        {
            if (inventoryItem != null && inventoryItem.Data && inventoryItem.Data.Sprite)
            {
                spriteSlot.sprite = inventoryItem.Data.Sprite;
            }

            this.item = inventoryItem;
        }

        internal void ActivateBorder()
        {
            slotBackground.color = Color.red;
        }

        internal void RemoveBorder()
        {
            slotBackground.color = Color.clear;
        }


    }
}