using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.PlayerControl.Logic {
    public class InputHandler : MonoBehaviour {
        public Action onAttack;
        public Action<InputValue> onScroll;

        public void OnAttack(InputValue value) {
            this.onAttack?.Invoke();
        }

        public void OnScroll(InputValue value)
        {
            this.onScroll?.Invoke(value);
        }
    }
}
