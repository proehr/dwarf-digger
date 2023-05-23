using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    
    // TODO: Physics.IgnoreCollision on instantiation by other combat participant
    public class AggroPullingParticipant : AbstractCombatParticipant
    {
        [SerializeField] private GameObject projectileLaunchOrigin;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private float aggroRange;
        [SerializeField] private SphereCollider aggroCollider;
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
            CheckForHit();
            GameObject projectile = Instantiate(projectilePrefab, projectileLaunchOrigin.transform);
            StartCoroutine(MoveProjectile());
        }

        private IEnumerator MoveProjectile()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerator CheckForHit()
        {
            throw new NotImplementedException();
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