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
            Instantiate(prefab, playerTransform.position + (playerTransform.forward * 2), Quaternion.identity);
        }
    }
}