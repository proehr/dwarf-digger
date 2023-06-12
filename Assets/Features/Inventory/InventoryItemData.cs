namespace Features.Inventory {
    using UnityEngine;

    public class InventoryItemData : ScriptableObject {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public Sprite Sprite { get; set; }
        public GameObject Prefab { get; set; }
        public int MaxStackSize { get; set; }
        
    }
}
