using System;
using Common.Logic.Variables;
using UnityEngine;

namespace Features.Combat.Logic
{
    [Serializable]
    public class HealthStats
    {
        [SerializeField] private IntReference health;
        [SerializeField] private IntReference maxHealth;
        
        public IntReference Health
        {
            get => health;
            set => health = value;
        }

        public IntReference MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }
    }
}