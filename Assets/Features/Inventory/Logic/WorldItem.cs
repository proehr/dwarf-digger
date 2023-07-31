using UnityEngine;

namespace Features.Inventory.Logic
{
    public class WorldItem : MonoBehaviour {
        [SerializeField] private InventoryItem inventoryItem;
        
        public void PickUp(PlayerInventory inventory) {
            if (inventory.AddItemToInventory(inventoryItem)) {
                Destroy(this);
            }
        }
    }
}
