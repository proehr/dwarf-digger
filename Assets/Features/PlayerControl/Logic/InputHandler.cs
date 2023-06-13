using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.PlayerControl.Logic {
    public class InputHandler : MonoBehaviour {
        public Action onAttack;
        public Action<InputValue> onScroll;
        public Action onPickUp;
        public Action onInventoryInteraction;
        
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
    }
}
