using Common.Logic.Variables;
using Features.PlayerControl.Logic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Inventory.Logic.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private PlayerInventory inventory;
        [SerializeField] private UiItemSlot[] uiItemSlots;
        [SerializeField] private IntVariable activeSlot;

        private void Awake()
        {
            inputHandler.onScroll += HandleScroll;
            for (int i = 0; i < inventory.inventory.Length; i++)
            {
                uiItemSlots[i].SetItem(inventory.inventory[i]);
            }
            uiItemSlots[activeSlot.Get()].ActivateBorder();
        }

        private void HandleScroll(InputValue inputValue)
        {
            float value = inputValue.Get<float>();
            if (value > 0)
            {
                ScrollUp();
            }
            else if (value < 0)
            {
                ScrollDown();
            }
        }

        private void ScrollUp()
        {
            uiItemSlots[activeSlot.Get()].RemoveBorder();
            activeSlot.Set(Mod(activeSlot.Get() + 1, uiItemSlots.Length));
            uiItemSlots[activeSlot.Get()].ActivateBorder();
        }
        
        private void ScrollDown()
        {
            uiItemSlots[activeSlot.Get()].RemoveBorder();
            activeSlot.Set(Mod(activeSlot.Get() - 1, uiItemSlots.Length));
            uiItemSlots[activeSlot.Get()].ActivateBorder();
        }
        
        private int Mod(int x, int m) {
            return (x%m + m)%m;
        }
    }
}