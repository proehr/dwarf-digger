
namespace Features.Inventory.Logic {
    using System;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "InventoryItemData", menuName = "Features/Inventory/Logic/InventoryItemData")]
    public class InventoryItemData : ScriptableObject {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public Sprite Sprite { get; set; }
        public GameObject Prefab { get; set; }
        public int MaxStackSize { get; set; }
        
    }
}
