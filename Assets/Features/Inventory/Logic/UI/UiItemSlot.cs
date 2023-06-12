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
            if (inventoryItem != null && inventoryItem.data && inventoryItem.data.Sprite)
            {
                spriteSlot.sprite = inventoryItem.data.Sprite;
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