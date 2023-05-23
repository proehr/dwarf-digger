using System;
using System.Collections;
using Common.Logic.Variables;
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
            if (canMove.Get() && currentAttackStats.AttackCooldown <= 0)
            {
                Attack();
                canMove.SetFalse();
            }
        }

        protected override IEnumerator StopUse()
        {
            yield return StartCoroutine(base.StopUse());
            canMove.SetTrue();
        }
    }
}