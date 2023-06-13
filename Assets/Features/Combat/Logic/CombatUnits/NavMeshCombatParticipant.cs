using System;
using MyBox;
using UnityEngine;
using UnityEngine.AI;

namespace Features.Combat.Logic.CombatUnits
{
    public abstract class NavMeshCombatParticipant : MovingCombatParticipant
    {
        [SerializeField] protected NavMeshAgent agent;
        [SerializeField] protected internal AbstractCombatParticipant target;

        protected internal AbstractCombatParticipant initialTarget;

        protected internal override void ApplyMovementCooldown(float time)
        {
            currentMovementStats.MovementCooldown = Math.Max(currentMovementStats.MovementCooldown, time);
            if (currentMovementStats.MovementCooldown > 0)
            {
                agent.isStopped = true;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            //SetTarget(target);
            agent.speed = currentMovementStats.MaximumMovementSpeed;
        }

        protected virtual void Update()
        {
            
            if (currentMovementStats.MovementCooldown > 0)
            {
                currentMovementStats.MovementCooldown = Math.Max(currentMovementStats.MovementCooldown - Time.deltaTime, 0);
            }

            agent.isStopped = currentMovementStats.MovementCooldown > 0;
            if (target)
            {
                agent.destination = target.transform.position;
            }
        }

        internal void SetTarget(AbstractCombatParticipant targetParticipant)
        {
            if (initialTarget == null)
            {
                initialTarget = targetParticipant;
            }
            target = targetParticipant;
            Debug.Log("Init Target: " + initialTarget + " Target: " + target);
            target.deathListeners += ResetTarget;
            agent.destination = target.transform.position;
        }

        private void ResetTarget(AbstractCombatParticipant abstractCombatParticipant)
        {
            target = initialTarget;
        }
        
    }
}