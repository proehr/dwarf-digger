using System;
using Common.Logic.Variables;
using Features.PlayerControl.Logic;
using Features.StateSwitch.Logic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Combat.Logic.CombatUnits
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerCombatParticipant : MovingCombatParticipant
    {
        [SerializeField] private BoolVariable canMove;
        [SerializeField] private InputHandler handler;

        private GameState currentPlayerState;

        private void Update()
        {
            if (isAttacking)
            {
                canMove.SetFalse();
            }
            else
            {
                canMove.SetTrue();
            }
            
            if (currentAttackStats.AttackCooldown > 0)
            {
                currentAttackStats.AttackCooldown = Math.Max(currentAttackStats.AttackCooldown - Time.deltaTime, 0);
            }
        }

        protected internal override void ApplyMovementCooldown(float time)
        {
            currentMovementStats.MovementCooldown = Math.Max(currentMovementStats.MovementCooldown, time);
            if (currentMovementStats.MovementCooldown > 0)
            {
                canMove.SetFalse();
            }
        }

        public void StartAttack()
        {
            if (currentAttackStats.AttackCooldown <= 0)
            {
                Attack();
                canMove.SetFalse();
            }
        }

        public void OnEnable() {
            tool.enabled = true;
        }

        public void OnDisable() {
            canMove.SetTrue();
            tool.enabled = false;
        }
    }
}
