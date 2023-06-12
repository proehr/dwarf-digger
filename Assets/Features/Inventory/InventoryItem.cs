namespace Features.Inventory {
    using System;
    using UnityEngine;

    [Serializable]
    public class InventoryItem {
        [SerializeField] private InventoryItemData data;
        [SerializeField] private int currentStackSize;
        [SerializeField] private Interactable interaction;
        
        public int CurrentStackSize {
            get => currentStackSize;
        }

        public bool AddToStack() {
            if (currentStackSize >= data.MaxStackSize) return false;
            currentStackSize++;
            return true;
        }

        public void RemoveFromStack() {
            currentStackSize--;
        }

        public GameObject GetPrefab() {
            return data.Prefab;
        }
        
        public bool CheckName(InventoryItem item) {
            return data.ItemName == item.data.ItemName;
        }

        public bool CheckId(InventoryItem item) {
            return data.Id == item.data.Id;
        }

        public void OnInteraction() {
            interaction.Interact(data);
        }
        
    }
}
