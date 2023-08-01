using UnityEngine;

namespace Features.Combat.Logic.CombatUnits
{
    public class AggroPullHelper : MonoBehaviour
    {
        [SerializeField] protected internal AggroPullingParticipant pullingParticipant;
        [SerializeField] private CapsuleCollider aggroCollider;

        private void Awake()
        {
            aggroCollider.radius = pullingParticipant.aggroRange;
        }

        private void OnTriggerEnter(Collider other)
        {
            AbstractCombatParticipant target = other.GetComponent<AbstractCombatParticipant>();
            if (target && target.combatantGroup != pullingParticipant.combatantGroup && !pullingParticipant.targets.Contains(target))
            {
                NavMeshCombatParticipant navMeshCombatParticipant = target as NavMeshCombatParticipant;
                if (navMeshCombatParticipant && navMeshCombatParticipant.initialTarget == navMeshCombatParticipant.target)
                {
                    AddTarget(navMeshCombatParticipant);
                }
            }
        }
        
        private void OnCollisionExit(Collision other)
        
        {
            AbstractCombatParticipant target = other.collider.GetComponent<AbstractCombatParticipant>();
            if (target)
            {
                pullingParticipant.targets.Remove(target);
            }
        }

        public void AddTarget(AbstractCombatParticipant abstractCombatParticipant)
        {
            if (abstractCombatParticipant.combatantGroup != pullingParticipant.combatantGroup)
            {
                pullingParticipant.targets.Add(abstractCombatParticipant);
                Debug.Log("Target added to turret");
                abstractCombatParticipant.deathListeners += RemoveTarget;
                NavMeshCombatParticipant navMeshCombatParticipant = abstractCombatParticipant as NavMeshCombatParticipant;
                if (navMeshCombatParticipant && navMeshCombatParticipant.target == navMeshCombatParticipant.initialTarget)
                {
                    navMeshCombatParticipant.SetTarget(pullingParticipant);
                }
            }
        }

        private void RemoveTarget(AbstractCombatParticipant abstractCombatParticipant)
        {
            pullingParticipant.targets.Remove(abstractCombatParticipant);
        }
    }
}