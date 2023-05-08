using System;
using Common.Logic.Variables;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Combat.Logic.CombatUnits
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerCombatParticipant : MovingCombatParticipant
    {
        [SerializeField] private BoolVariable canMove;

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

        private void OnAttack()
        {
            if (currentAttackStats.AttackCooldown <= 0)
            {
                Attack();
                canMove.SetFalse();
            }
        }
    }
}