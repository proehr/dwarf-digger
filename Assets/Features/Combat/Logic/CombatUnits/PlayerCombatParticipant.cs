using System;
using Common.Logic.Variables;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Combat.Logic.CombatUnits
{
    using PlayerControl.Logic;
    using StateSwitch.Logic;

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

        private void StartAttack()
        {
            if (currentAttackStats.AttackCooldown <= 0)
            {
                Attack();
                canMove.SetFalse();
            }
        }

        public void OnEnable() {
            tool.enabled = true;
            handler.onAttack += StartAttack;
        }

        public void OnDisable() {
            canMove.SetTrue();
            tool.enabled = false;
            handler.onAttack -= StartAttack;
        }
    }
}
