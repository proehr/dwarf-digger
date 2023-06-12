using System;
using System.Collections;
using System.Collections.Generic;
using Features.Inventory.Logic;
using Features.PlayerControl.Logic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Transform playerTransform;
    
    
    private List<Collider> itemsInRange;

    public void Start() {
        itemsInRange = new List<Collider>();
        inputHandler.onPickUp += PickUp;
        inputHandler.onInventoryInteraction += OnInteraction;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Item") && !itemsInRange.Contains(other)) {
            itemsInRange.Add(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("Item")) {
            itemsInRange.Remove(other);
        }
    }

    private void OnInteraction() {
        inventory.UseSelectedIndex(playerTransform);
    }
    
    private Collider GetClosestItem() {
        Collider nearestItem = null;
        float nearestDistance = Single.MaxValue;
        
        foreach (Collider currentItem in itemsInRange) {
            float currentDistance = Vector3.Distance(this.transform.position, currentItem.transform.position);
            
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
