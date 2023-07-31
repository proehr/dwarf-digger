using Features.Combat.Logic.CombatUnits;
using UnityEngine;

namespace Features.Inventory.Logic.InventoryItems
{
    [CreateAssetMenu(fileName = "PlaceableItemData", menuName = "Features/Inventory/PlaceableItemData")]
    public class PlaceableItemData : InventoryItemData
    {
        protected internal override void Interact(PlayerCombatParticipant player)
        {
            var playerTransform = player.transform;
            RaycastHit[] raycastHits = Physics.RaycastAll(
                playerTransform.position + Vector3.up * 1,
                playerTransform.forward,
                2
            );
            if (raycastHits.Length > 0)
            {
                return;
            }
            Instantiate(prefab, playerTransform.position + (playerTransform.forward * 2), playerTransform.rotation);
        }
    }
}