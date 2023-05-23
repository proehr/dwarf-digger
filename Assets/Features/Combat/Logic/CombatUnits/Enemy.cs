using System;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class Enemy : NavMeshCombatParticipant
    {
        [SerializeField] private float maximumAttackDistance;
        
        protected override void Update()
        {
            base.Update();
            HandleCombat();
        }

        private void HandleCombat()
        {
            if (currentAttackStats.AttackCooldown > 0)
            {
                currentAttackStats.AttackCooldown = Math.Max(currentAttackStats.AttackCooldown - Time.deltaTime, 0);
            }
            else if (target 
                     && Vector3.Distance(target.transform.position, transform.position) < maximumAttackDistance
                     )
            {
                Attack();
            }
        }
    }
}