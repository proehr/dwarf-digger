using Features.Combat.Logic.CombatUnits;
using UnityEngine;

namespace Features.Inventory.Logic.InventoryItems
{
    [CreateAssetMenu(fileName = "CombatItemData", menuName = "Features/Inventory/CombatItemData")]
    public class CombatItemData : InventoryItemData
    {
        protected internal override void Interact(PlayerCombatParticipant player)
        {
            //Debug.Log("Triggered combat data");
            player.StartAttack();
        }
    }
}