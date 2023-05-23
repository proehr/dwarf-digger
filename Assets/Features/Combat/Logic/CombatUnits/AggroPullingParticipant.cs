using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private float aggroRange;
        [SerializeField] private CapsuleCollider aggroCollider;
        [SerializeField] private float rotationSpeed;
        //TODO: change to raycast: check if projectile is going to hit, then attack
        [SerializeField] private float maximumAttackAngle;

        internal List<AbstractCombatParticipant> targets = new();
        private Vector3 direction;
        private Quaternion lookRotation;

        protected override void Awake()
        {
            base.Awake();
            aggroCollider.radius = aggroRange;
        }

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
                if (Quaternion.Angle(transform.rotation, lookRotation) < maximumAttackAngle)
                {
                    Attack();
                }
            }
        }

        protected override void Attack()
        {
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
                transform.position += projectile.transform.forward * (projectileSpeed * Time.deltaTime);
                CheckForHit(projectile);
            }
            yield return null;
        }

        private void CheckForHit(GameObject projectile)
        {
            if (Physics.Raycast(projectile.transform.position,
                    projectile.transform.TransformDirection(Vector3.forward), out var hit,
                    hitDetectionRange))
            {
                AbstractCombatParticipant hitCombatParticipant = hit.collider.GetComponent<AbstractCombatParticipant>();
                if (hitCombatParticipant != null)
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