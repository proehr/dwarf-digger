using UnityEngine;

namespace Features.Inventory.Logic {
    using Unity.VisualScripting;

    [CreateAssetMenu(fileName = "PlayerInventory", menuName = "Features/Inventory/Logic/PlayerInventory")]
    public class PlayerInventory : ScriptableObject {
        [SerializeField] private int maxInventorySize;
        private const int ILLEGAL_SLOT = -1;
        
        internal InventoryItem[] inventory;
        private int selectedIndex;

        public void Awake() { inventory = new InventoryItem[maxInventorySize];
        }

        public void UseSelectedIndex(Transform playerTransform) {
            inventory[selectedIndex].Interact(playerTransform);
        }

        public void SelectIndex(int index) {
            if (!CheckInBounds(index)) return;
            this.selectedIndex = index;
        }

        public InventoryItem GetItemAtIndex(int index) {
            if (!CheckInBounds(index)) return null;
            return inventory[index];
        }

        public void DropItemAtIndex(int index) {
            if (!CheckInBounds(index)) return;
            inventory[index] = null;
        }

        public void SwapSlots(int from, int to) {
            if (!CheckInBounds(from) || !CheckInBounds(to)) return;
            if (inventory[from] == null) return;
            (inventory[to], inventory[from]) = (inventory[from], inventory[to]);
        }

        //TODO Maybe eine Map statt einem Array?
        public bool AddItemToInventory(InventoryItem itemToAdd) {
            int firstFreeSlot = ILLEGAL_SLOT;
            for (int i = 0; i < maxInventorySize; i++) {
                if (inventory[i] == null && firstFreeSlot == ILLEGAL_SLOT) {
                    firstFreeSlot = i;
                //Check for Stack
                } else if (inventory[i].CheckId(itemToAdd)) {
                    return inventory[i].AddToStack();
                }
            }
            //If Stack doesn't exist yet
            if (firstFreeSlot == ILLEGAL_SLOT) return false;
            itemToAdd.AddToStack();
            inventory[firstFreeSlot] = itemToAdd;
            return true;
        }

        public void RemoveItemFromInventory(int index) {
            if (!CheckInBounds(index)) return;
            InventoryItem item = inventory[index];
            if (item == null) return;
            item.RemoveFromStack();
            if (item.CurrentStackSize <= 0) {
                inventory[index] = null;
            }
        }

        private bool CheckInBounds(int index) {
            return (index < maxInventorySize || index >= 0);
        }
    }
}
