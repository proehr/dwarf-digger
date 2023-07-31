using System;
using Common.Logic.Variables;
using UnityEngine;
using UnityEngine.Serialization;

namespace Features.Combat.Logic
{
    [Serializable]
    public class MovementStats
    {
        [SerializeField] protected FloatReference maximumMovementSpeed;
        [SerializeField] protected float movementCooldown;

        public FloatReference MaximumMovementSpeed => maximumMovementSpeed;

        public float MovementCooldown
        {
            get => movementCooldown;
            set => movementCooldown = value;
        }
    }
}