using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Features.Combat.Logic.AttackEffects;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    
    // TODO: Physics.IgnoreCollision on instantiation by other combat participant
    public class AggroPullingParticipant : AbstractCombatParticipant
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float maximumAttackAngle;

        internal List<AbstractCombatParticipant> targets = new();
        private Vector3 direction;
        private Quaternion lookRotation;
        protected void Update()
        {
            HandleCombat();
        }

        private void HandleCombat()
        {
            RotateTowardsTarget();
            if (currentAttackStats.AttackCooldown > 0)
            {
                currentAttackStats.AttackCooldown = Math.Max(currentAttackStats.AttackCooldown - Time.deltaTime, 0);
            }
            else if (!isAttacking
                     && targets.Count > 0)
            {
                if (Quaternion.Angle(transform.rotation, lookRotation) < maximumAttackAngle)
                {
                    Attack();
                }
            }
        }

        protected override void Attack()
        {
            targets[0].ReceiveAttack(this, new DirectDamageEffect(currentAttackStats.AttackDamage));
        }

        private void RotateTowardsTarget()
        {
            if (targets.Count > 0)
            {
                direction = (targets[0].transform.position - transform.position).normalized;
                lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}