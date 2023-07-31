using System;
using MyBox;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public abstract class MovingCombatParticipant : AnimatedCombatParticipant
    {
        [SerializeField] protected internal MovementStats initialMovementStats;
        [SerializeField] protected MovementStats currentMovementStats;

        protected override void Awake()
        {
            base.Awake();
            currentMovementStats = initialMovementStats;
        }

        protected internal abstract void ApplyMovementCooldown(float time);
    }
}