namespace Features.Combat.Logic.CombatUnits {
    using System;
    using AttackEffects;
    using UnityEngine;

    public class Trap : MonoBehaviour {
        [SerializeField] private CombatantGroup combatantGroup;
        [SerializeField] private int damage;

        public void OnTriggerEnter(Collider other) {
            AbstractCombatParticipant target = other.GetComponent<AbstractCombatParticipant>();
            if (target && target.combatantGroup != combatantGroup)
            {
                target.ReceiveAttack(null, new DirectDamageEffect(damage));
            }
        }

    }
}
