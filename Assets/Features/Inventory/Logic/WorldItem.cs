using UnityEngine;

namespace Features.Inventory.Logic
{
    public class WorldItem : MonoBehaviour {
        [SerializeField] private InventoryItem inventoryItem;

        public void OnPickUp() {
            //TODO PickUp Logic (Wann wird das getriggered? Und wo?)
            //TODO if successful then destroy; else do nothing
        
            /*
         * Falls PlayerInventory ein Singleton ist,
         * dann könnte man sowas machen wie
         * if(PlayerInventory.Instance.AddItemToInventory(inventoryItem)){ //AddItemToInventory ist true wenn noch genügend Platz existiert
         *       Destroy(gameObject);
         * }
         *
         * Allerdings bin ich mir nicht sicher ob wir das als Singleton reference machen sollten
         * Was wären Pro/Contra Argumente?
         */
        }
    }
}
