using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Features.Combat.Logic.CombatUnits;
using MyBox;
using UnityEngine;

namespace Features.Combat.Logic
{
    [RequireComponent(typeof(Collider))]
    public abstract class AbstractCombatParticipant : MonoBehaviour
    {
        [SerializeField] protected internal CombatantGroup combatantGroup;

        [SerializeField] protected internal AttackStats initialAttackStats;
        [SerializeField] protected internal AttackStats currentAttackStats;

        [SerializeField] protected internal HealthStats initialHealthStats;
        [SerializeField] protected internal HealthStats currentHealthStats;

        protected bool isAttacking;

        protected internal Action<AbstractCombatParticipant> deathListeners;

        protected virtual void Awake()
        {
            currentAttackStats = initialAttackStats;
            currentHealthStats = initialHealthStats;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            CombatTool combatTool = other.GetComponent<CombatTool>();
            if (combatTool && combatTool.user.combatantGroup != combatantGroup && combatTool.user.isAttacking)
            {
                combatTool.ApplyAttackEffects(this);
            }
            
            // TODO this should be moved somewhere else. Reconsider the whole collision logic in combat
            AggroPullHelper aggroPullHelper = other.GetComponent<AggroPullHelper>();
            if (aggroPullHelper)
            {
                aggroPullHelper.AddTarget(this);
            }
        }

        protected internal virtual void ReceiveAttack(AbstractCombatParticipant source, params AttackEffect[] effects)
        {
            ReceiveAttackEffects(source, effects);
            if (currentHealthStats.Health <= 0f)
            {
                HandleDeath(source);
            }
        }

        private void ReceiveAttackEffects(AbstractCombatParticipant source, AttackEffect[] effects)
        {
            foreach (AttackEffect effect in effects)
            {
                effect.Apply(this, source);
            }
        }

        protected internal virtual void ReceiveDamage(int amount)
        {
            currentHealthStats.Health.Set(currentHealthStats.Health - amount);
        }

        protected virtual void HandleDeath(AbstractCombatParticipant killer)
        {
            deathListeners?.Invoke(this);
            Destroy(gameObject);
        }

        protected virtual void Attack()
        {
            isAttacking = true;
            ApplyAttackCooldown(1 / currentAttackStats.AttackSpeed);
        }
        

        public void ApplyAttackCooldown(float time)
        {
            currentAttackStats.AttackCooldown = Math.Max(currentAttackStats.AttackCooldown, time);
        }
    }
}