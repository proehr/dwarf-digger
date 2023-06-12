using System.Collections;
using System.Collections.Generic;
using Features.Inventory;
using UnityEngine;

public class TurretInteraction : MonoBehaviour, Interactable
{
    public void Interact(InventoryItemData data) {
        GameObject turret = data.Prefab;
        //TODO Turret and richtige Stelle instanziieren
    }
}
