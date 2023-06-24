using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.PlayerControl.Logic {
    public class InputHandler : MonoBehaviour {
        public Action onAttack;
        public Action<InputValue> onScroll;
        public Action onPickUp;
        public Action onInventoryInteraction;
        public Action<int> onHotbarKey;
        
        public void OnAttack(InputValue value) {
            this.onAttack?.Invoke();
        }

        public void OnScroll(InputValue value)
        {
            this.onScroll?.Invoke(value);
        }

        public void OnPickUp(InputValue value) {
            onPickUp?.Invoke();
        }

        public void OnInventoryInteraction(InputValue value) {
            onInventoryInteraction?.Invoke();
        }

        public void OnHotbarOne(InputValue value) {
            Debug.Log("Input Key 1");
            onHotbarKey?.Invoke(1);
        }

        public void OnHotbarTwo(InputValue value) {
            Debug.Log("Input Key 2");
            onHotbarKey?.Invoke(2);
        }

        public void OnHotbarThree(InputValue value) {
            Debug.Log("Input Key 3");
            onHotbarKey?.Invoke(3);

        }

        public void OnHotbarFour(InputValue value) {
            onHotbarKey?.Invoke(4);

        }

        public void OnHotbarFive(InputValue value) {
            onHotbarKey?.Invoke(5);

        }

        public void OnHotbarSix(InputValue value) {
            onHotbarKey?.Invoke(6);

        }

        public void OnHotbarSeven(InputValue value) {
            onHotbarKey?.Invoke(7);

        }

        public void OnHotbarEight(InputValue value) {
            onHotbarKey?.Invoke(8);

        }

        public void OnHotbarNine(InputValue value) {
            onHotbarKey?.Invoke(9);

        }

        public void OnHotbarZero(InputValue value) {
            onHotbarKey?.Invoke(0);

        }
    }
}
