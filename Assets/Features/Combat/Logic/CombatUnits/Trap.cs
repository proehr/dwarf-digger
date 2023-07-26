using Features.Combat.Logic.AttackEffects;
using UnityEngine;

namespace Features.Combat.Logic.CombatUnits {
    public class Trap : MonoBehaviour {
        [SerializeField] private CombatantGroup combatantGroup;
        [SerializeField] private int damage;
        [SerializeField] private AudioClip hitFx;
        [SerializeField] private AudioSource audioSource;

        public void OnTriggerEnter(Collider other) {
            AbstractCombatParticipant target = other.GetComponent<AbstractCombatParticipant>();
            if (target && target.combatantGroup != combatantGroup)
            {
                audioSource.clip = hitFx;
                audioSource.Play();
                target.ReceiveAttack(null, new DirectDamageEffect(damage));
            }
        }

    }
}
