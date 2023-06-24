using System;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class Enemy : NavMeshCombatParticipant
    {
        [SerializeField] private float maximumAttackDistance;
        [SerializeField] private float rotationSpeed;
        
        private Vector3 direction;
        private Quaternion lookRotation;


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
                     && Vector3.Distance(target.transform.position, transform.position) < tool.maxHitDistance
                    )
            {
                /*RotateTowardsTarget();
                RaycastHit[] hits = Physics.RaycastAll(transform.position,
                    transform.forward,
                    maximumAttackDistance);
                if (hits.Any(hit => hit.collider.gameObject == target.gameObject))
                {*/
                    Attack();
                //}
            }
        }
        
        private void RotateTowardsTarget()
        {
            direction = (target.transform.position - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        
    }
    
}