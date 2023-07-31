using Common.Logic.Variables;
using Features.PlayerControl.Logic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Inventory.Logic.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private PlayerInventory inventory;
        [SerializeField] private UiItemSlot[] uiItemSlots;
        [SerializeField] private IntVariable activeSlot;
        private int previousSlot;

        private void Awake()
        {
            activeSlot.GetChangedEvent().RegisterListener(OnScroll);
            for (int i = 0; i < inventory.inventory.Length; i++)
            {
                uiItemSlots[i].SetItem(inventory.inventory[i]);
            }
            uiItemSlots[activeSlot.Get()].ActivateBorder();
        }

        private void OnScroll() {
            uiItemSlots[previousSlot].RemoveBorder();
            uiItemSlots[activeSlot.Get()].ActivateBorder();
            previousSlot = activeSlot.Get();
        }
    }
}