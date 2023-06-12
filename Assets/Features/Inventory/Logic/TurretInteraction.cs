using UnityEngine;

namespace Features.Inventory.Logic
{
    public class TurretInteraction : Interactable
    {
        public override void Interact(InventoryItem item, Transform playerTransform) {
            GameObject turret = item.data.Prefab;
            Instantiate(turret, playerTransform.position + (playerTransform.forward * 2), Quaternion.identity);
            item.RemoveFromStack();
        }
    }
}
