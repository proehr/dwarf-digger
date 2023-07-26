using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Features.Combat.Logic.AttackEffects;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    
    // TODO: Physics.IgnoreCollision on instantiation by other combat participant
    // TODO: Move turret/projectile logic out
    public class AggroPullingParticipant : AbstractCombatParticipant
    {
        [SerializeField] private GameObject projectileLaunchOrigin;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private float hitDetectionRange;
        [SerializeField] internal float aggroRange;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private AudioClip attackFx;

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
            else if (targets.Count > 0)
            {
                RaycastHit[] hits = Physics.RaycastAll(transform.position,
                    transform.forward,
                    attackRange);
                if (hits.Any(hit => hit.collider.gameObject == targets[0].gameObject))
                {
                    Attack();
                }
            }
        }

        protected override void Attack()
        {
            base.Attack();
            audioSource.clip = attackFx;
            audioSource.Play();
            direction = (targets[0].transform.position - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            GameObject projectile = Instantiate(
                projectilePrefab, 
                projectileLaunchOrigin.transform.position,
                lookRotation
            );
            StartCoroutine(MoveProjectile(projectile, projectile.transform.position));
        }

        private IEnumerator MoveProjectile(GameObject projectile, Vector3 initialPosition)
        {
            while (Vector3.Distance(projectile.transform.position, initialPosition) < attackRange)
            {
                projectile.transform.position += projectile.transform.forward * (projectileSpeed * Time.deltaTime);
                CheckForHit(projectile);
                yield return null;
            }
            Destroy(projectile);
        }

        private void CheckForHit(GameObject projectile)
        {
            RaycastHit[] hits = Physics.RaycastAll(projectile.transform.position,
                projectile.transform.forward,
                hitDetectionRange);
            foreach (RaycastHit hit in hits)
            {
                AbstractCombatParticipant hitCombatParticipant = hit.collider.GetComponent<AbstractCombatParticipant>();
                if (hitCombatParticipant != null && hitCombatParticipant.combatantGroup != combatantGroup)
                {
                    hitCombatParticipant.ReceiveAttack(this, new DirectDamageEffect(currentAttackStats.AttackDamage));
                }
            }
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