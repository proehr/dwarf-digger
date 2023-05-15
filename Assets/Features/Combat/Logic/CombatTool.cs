using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Features.Combat.Logic
{
    /**
     * Any type of weapon or tool that is used by a <see cref="AbstractCombatParticipant"/>
     */
    [RequireComponent(typeof(Collider))]
    public abstract class CombatTool : MonoBehaviour
    {
        [SerializeField] internal string animationName;
        [SerializeField] private string animationTriggerName;

        protected internal int animationTriggerId;
        protected internal float animationLength;
        protected internal AbstractCombatParticipant user;

        private void Awake()
        {
            animationTriggerId = Animator.StringToHash(animationTriggerName);
        }

        public void Start() {
            
        }

        protected internal abstract void ApplyAttackEffects(AbstractCombatParticipant target);
    }
}