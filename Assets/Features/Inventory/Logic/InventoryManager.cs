using System;
using System.Collections.Generic;
using Common.Logic.Variables;
using Features.Combat.Logic.CombatUnits;
using Features.PlayerControl.Logic;
using UnityEngine;

namespace Features.Inventory.Logic
{
    using UnityEngine.InputSystem;

    public class InventoryManager : MonoBehaviour {
        [SerializeField] private PlayerInventory inventory;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private PlayerCombatParticipant player;
        [SerializeField] private IntVariable selectedIndex;

        private List<Collider> itemsInRange;

        public void Start() {
            itemsInRange = new List<Collider>();
            inputHandler.onPickUp += PickUp;
            inputHandler.onAttack += OnInteraction;
            inputHandler.onScroll += HandleScroll;
            inputHandler.onHotbarKey += OnHotbarKey;
            selectedIndex.GetChangedEvent().RegisterListener(OnSelectionChange);
        }

        private void OnHotbarKey(int key) {
            selectedIndex.Set(key != 0 ? key - 1 : 9);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.tag.Equals("Item") && !itemsInRange.Contains(other)) {
                Debug.Log("Added to List");
                itemsInRange.Add(other);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.tag.Equals("Item")) {
                Debug.Log("Remove from List");
                itemsInRange.Remove(other);
            }
        }
        
        private void OnSelectionChange()
        {
            inventory.SelectIndex(selectedIndex.Get(), player);
        }

        private void OnInteraction() {
            inventory.UseSelectedIndex(selectedIndex.Get(), player);
        }
    
        private Collider GetClosestItem() {
            Collider nearestItem = null;
            float nearestDistance = Single.MaxValue;
        
            foreach (Collider currentItem in itemsInRange) {
                float currentDistance = Vector3.Distance(this.transform.position, currentItem.transform.position);
                Debug.Log("Distance to Item: " + currentDistance + ", Item: " + currentItem.name);
                if (currentDistance < nearestDistance) {
                    nearestDistance = currentDistance;
                    nearestItem = currentItem;
                }
            }
            return nearestItem;
        }

        //TODO Maybe kann man InventoryItem direkt zum MonoBehaviour machen, dann würde WorldItem wegfallen...
        public void PickUp() {
            Collider itemToPickCollider = GetClosestItem();
            WorldItem itemToPickUp = itemToPickCollider.GetComponent<WorldItem>();
            itemToPickUp.PickUp(inventory);
            itemsInRange.Remove(itemToPickCollider);
        }
        
        private void HandleScroll(InputValue inputValue)
        {
            float value = inputValue.Get<float>();
            if (value > 0)
            {
                selectedIndex.Set(Mod(selectedIndex.Get() - 1, inventory.MaxInventorySize));
            }
            else if (value < 0)
            {
                selectedIndex.Set(Mod(selectedIndex.Get() + 1, inventory.MaxInventorySize));
            }
        }
        
        private int Mod(int x, int m) {
            return (x%m + m)%m;
        }

        private void OnDestroy() {
            inputHandler.onPickUp -= PickUp;
            inputHandler.onInventoryInteraction -= OnInteraction;

        }

        private void OnDisable() {
            inputHandler.onPickUp -= PickUp;
            inputHandler.onInventoryInteraction -= OnInteraction;

        }
    }
}
