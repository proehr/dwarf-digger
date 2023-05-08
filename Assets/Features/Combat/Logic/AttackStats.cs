using System;
using Common.Logic.Variables;
using UnityEngine;

namespace Features.Combat.Logic
{
    [Serializable]
    public class AttackStats
    {
        [SerializeField] private float attackSpeed;
        [SerializeField] private int attackDamage;
        [SerializeField] private float attackCooldown;

        public float AttackSpeed
        {
            get => attackSpeed;
            set => attackSpeed = value;
        }

        public int AttackDamage
        {
            get => attackDamage;
            set => attackDamage = value;
        }

        public float AttackCooldown
        {
            get => attackCooldown;
            set => attackCooldown = value;
        }
    }
}