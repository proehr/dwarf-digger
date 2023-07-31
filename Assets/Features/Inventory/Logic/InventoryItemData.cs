using Features.Combat.Logic;
using Features.Combat.Logic.CombatUnits;
using UnityEngine;

namespace Features.Inventory.Logic
{
    public abstract class InventoryItemData : ScriptableObject
    {
        public int id;
        public string itemName;
        public Sprite sprite;
        public GameObject prefab;
        public int maxStackSize;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }

        public Sprite Sprite
        {
            get => sprite;
            set => sprite = value;
        }

        public GameObject Prefab
        {
            get => prefab;
            set => prefab = value;
        }

        public int MaxStackSize
        {
            get => maxStackSize;
            set => maxStackSize = value;
        }

        protected internal abstract void Interact(PlayerCombatParticipant player);

        protected internal void Select(PlayerCombatParticipant player)
        {
            CombatTool combatTool = prefab.GetComponent<CombatTool>();
            // can be null to remove the player combat tool
            // super hacky but .. works for now
            player.SetTool(combatTool);
        }
    }
}