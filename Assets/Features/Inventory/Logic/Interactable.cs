namespace Features.Inventory.Logic {
    using UnityEngine;

    public abstract class Interactable : MonoBehaviour {
        public abstract void Interact(InventoryItem item, Transform playerTransform);
    }
}
