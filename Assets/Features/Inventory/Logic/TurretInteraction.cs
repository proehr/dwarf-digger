using UnityEngine;

namespace Features.Inventory.Logic
{
    public class TurretInteraction : MonoBehaviour, Interactable
    {
        public void Interact(InventoryItemData data) {
            GameObject turret = data.Prefab;
            //TODO Turret and richtige Stelle instanziieren
        }
    }
}
