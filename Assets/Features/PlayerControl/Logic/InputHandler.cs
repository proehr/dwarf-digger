using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

namespace Features.PlayerControl.Logic {
    using System;
    using UnityEngine.InputSystem;

    public class InputHandler : MonoBehaviour {
        public Action onAttack;

        public void OnAttack(InputValue value) {
            Debug.Log("TRiggered");
            this.onAttack?.Invoke();
        }
    }
}